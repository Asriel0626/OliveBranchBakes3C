using OliveBranchBakes.Models;

namespace OliveBranchBakes.Services;

public sealed class PickupService : SchedulingService
{
    public PickupService(BakerySettings settings)
        : base(settings)
    {
    }

    public override void Validate(
        IReadOnlyCollection<OrderItem> items,
        IReadOnlyCollection<BakeryProduct> products,
        IReadOnlyCollection<BakeryOrder> orders,
        DateTime placedAt,
        DateTime pickupAt)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentNullException.ThrowIfNull(products);
        ArgumentNullException.ThrowIfNull(orders);

        if (items.Count == 0)
            throw new InvalidOperationException(
                "Add at least one item to your cart.");

        if (pickupAt < placedAt.AddHours(Settings.MinimumAdvanceHours))
            throw new InvalidOperationException(
                $"Pickup must be at least {Settings.MinimumAdvanceHours} hours after ordering.");

        if (pickupAt > placedAt.AddDays(Settings.MaximumAdvanceDays))
            throw new InvalidOperationException(
                $"Pickup must be within {Settings.MaximumAdvanceDays} days of ordering.");

        if (pickupAt.Month == 12 && pickupAt.Day == 25)
            throw new InvalidOperationException(
                "The bakery is closed on December 25.");

        bool thanksgiving =
            pickupAt.Month == 11 &&
            pickupAt.DayOfWeek == DayOfWeek.Thursday &&
            pickupAt.Day >= 22 &&
            pickupAt.Day <= 28;

        if (thanksgiving)
            throw new InvalidOperationException(
                "The bakery is closed on Thanksgiving Day.");

        foreach (var item in items)
        {
            item.Validate();

            if (item.Quantity > ShoppingCartService.MaximumQuantityPerItem)
                throw new InvalidOperationException(
                    $"The maximum quantity per item is {ShoppingCartService.MaximumQuantityPerItem}.");

            var product = products.FirstOrDefault(product =>
                product.Id.Equals(
                    item.ProductId,
                    StringComparison.OrdinalIgnoreCase));

            if (product is null || !product.IsAvailableOn(pickupAt))
                throw new InvalidOperationException(
                    $"{item.ProductName} is not available on the selected pickup date.");
        }

        int requestedPies = items
            .Where(item => IsPie(item, products))
            .Sum(item => item.Quantity);

        int remainingPies = GetRemainingPies(
            orders, products, pickupAt);

        if (requestedPies > remainingPies)
            throw new InvalidOperationException(
                $"Only {remainingPies} pies remaining for {pickupAt:MM/dd/yyyy}. " +
                $"Your cart contains {requestedPies}. " +
                "Choose fewer pies or another pickup date.");
    }

    public override int GetRemainingPies(
        IReadOnlyCollection<BakeryOrder> orders,
        IReadOnlyCollection<BakeryProduct> products,
        DateTime pickupAt)
    {
        ArgumentNullException.ThrowIfNull(orders);
        ArgumentNullException.ThrowIfNull(products);

        int reservedPies = orders
            .Where(order =>
                order.PickupAt.Date == pickupAt.Date &&
                order.Status != OrderStatus.Cancelled)
            .SelectMany(order => order.Items)
            .Where(item => IsPie(item, products))
            .Sum(item => item.Quantity);

        return Math.Max(0, Settings.DailyPieLimit - reservedPies);
    }

    private static bool IsPie(
        OrderItem item,
        IReadOnlyCollection<BakeryProduct> products)
    {
        string category = item.CategoryId;

        if (string.IsNullOrWhiteSpace(category))
        {
            var product = products.FirstOrDefault(product =>
                product.Id.Equals(
                    item.ProductId,
                    StringComparison.OrdinalIgnoreCase));

            category = product?.CategoryId ?? "";
        }

        return category.Equals(
            "Pies",
            StringComparison.OrdinalIgnoreCase);
    }
}