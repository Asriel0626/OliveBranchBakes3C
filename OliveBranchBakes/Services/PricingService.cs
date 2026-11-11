using OliveBranchBakes.Models;
namespace OliveBranchBakes.Services;

public interface IPricingService
{
    PricingResult Calculate(
        IReadOnlyCollection<OrderItem> items,
        IReadOnlyCollection<BakeryProduct> products,
        DateTime placedAt,
        DateTime pickupAt);
}

public abstract class PricingService : IPricingService
{
    protected BakerySettings Settings { get; }

    protected PricingService(BakerySettings settings)
    {
        Settings = settings ??
            throw new ArgumentNullException(nameof(settings));
    }

    public abstract PricingResult Calculate(
        IReadOnlyCollection<OrderItem> items,
        IReadOnlyCollection<BakeryProduct> products,
        DateTime placedAt,
        DateTime pickupAt);
}

public sealed class PlanAheadPricingService : PricingService
{
    public PlanAheadPricingService(BakerySettings settings)
        : base(settings)
    {
    }

    public override PricingResult Calculate(
        IReadOnlyCollection<OrderItem> items,
        IReadOnlyCollection<BakeryProduct> products,
        DateTime placedAt,
        DateTime pickupAt)
    {
        ArgumentNullException.ThrowIfNull(items);
        ArgumentNullException.ThrowIfNull(products);

        if (items.Count == 0)
            throw new ArgumentException("The cart is empty.");

        if (pickupAt <= placedAt)
            throw new ArgumentException(
                "Pickup must be after the order time.");

        var menu = products.ToDictionary(
            product => product.Id,
            StringComparer.OrdinalIgnoreCase);

        decimal subtotal = 0m;
        decimal discount = 0m;

        bool planAhead = pickupAt - placedAt >=
            TimeSpan.FromDays(Settings.PlanAheadDays);

        foreach (var item in items)
        {
            item.Validate();

            if (!menu.TryGetValue(item.ProductId, out var product))
                throw new InvalidOperationException(
                    "A product in the cart was not found.");

            subtotal += item.LineTotal;

            bool eligible =
                product.CategoryId.Equals(
                    "Pies", StringComparison.OrdinalIgnoreCase) ||
                product.CategoryId.Equals(
                    "Cakes", StringComparison.OrdinalIgnoreCase);

            if (planAhead && eligible)
                discount +=
                    Settings.PlanAheadItemDiscount * item.Quantity;
        }

        decimal fees = pickupAt - placedAt <
            TimeSpan.FromHours(Settings.RushFeeThresholdHours)
            ? Settings.RushFeeAmount
            : 0m;

        decimal taxableAmount = subtotal - discount + fees;
        decimal tax = taxableAmount * Settings.TaxRate;

        return new PricingResult(
            subtotal, discount, fees, tax);
    }
}
