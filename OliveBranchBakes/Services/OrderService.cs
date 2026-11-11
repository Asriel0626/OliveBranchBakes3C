using OliveBranchBakes.Data;
using OliveBranchBakes.Models;

namespace OliveBranchBakes.Services;

public sealed class OrderService
{
    private readonly DataStore _store;
    private readonly IPricingService _pricing;
    private readonly SchedulingService _scheduling;
    private readonly CustomerAccountService _accounts;

    public OrderService(
        DataStore store,
        IPricingService pricing,
        SchedulingService scheduling,
        CustomerAccountService accounts)
    {
        _store = store ??
            throw new ArgumentNullException(nameof(store));

        _pricing = pricing ??
            throw new ArgumentNullException(nameof(pricing));

        _scheduling = scheduling ??
            throw new ArgumentNullException(nameof(scheduling));

        _accounts = accounts ??
            throw new ArgumentNullException(nameof(accounts));
    }

    public PricingResult Preview(
        ShoppingCartService cart,
        DateTime placedAt,
        DateTime pickupAt)
    {
        var items = CreateOrderItems(cart);
        return Calculate(items, placedAt, pickupAt);
    }

    public BakeryOrder PlaceOrder(
        ShoppingCartService cart,
        string name,
        string phone,
        DateTime pickupAt,
        string notes = "")
    {
        ValidateContact(name, phone);

        notes ??= "";

        if (notes.Length > 500)
        {
            throw new ArgumentException(
                "Keep order notes to 500 characters or fewer.");
        }

        DateTime placedAt = DateTime.Now;
        var items = CreateOrderItems(cart);
        PricingResult price = Calculate(items, placedAt, pickupAt);

        var order = new BakeryOrder(
            NextConfirmationNumber(placedAt),
            _accounts.CurrentCustomer?.Id,
            name,
            phone,
            placedAt,
            pickupAt,
            items)
        {
            Status = OrderStatus.Received,
            Notes = notes.Trim(),
            Discount = RoundMoney(price.Discount),
            Fees = RoundMoney(price.Fees),
            Tax = RoundMoney(price.Tax)
        };

        _store.SaveOrder(order);
        cart.Clear();

        return order;
    }

    private PricingResult Calculate(
        IReadOnlyCollection<OrderItem> items,
        DateTime placedAt,
        DateTime pickupAt)
    {
        _scheduling.Validate(
            items,
            _store.Products,
            _store.Orders,
            placedAt,
            pickupAt);

        return _pricing.Calculate(
            items,
            _store.Products,
            placedAt,
            pickupAt);
    }

    private List<OrderItem> CreateOrderItems(
        ShoppingCartService cart)
    {
        ArgumentNullException.ThrowIfNull(cart);

        var items = new List<OrderItem>();

        foreach (var line in cart.Items)
        {
            var product = _store.Products.FirstOrDefault(product =>
                product.Id.Equals(
                    line.ProductId,
                    StringComparison.OrdinalIgnoreCase));

            if (product is null)
            {
                throw new InvalidOperationException(
                    $"{line.ProductName} is no longer on the menu.");
            }

            items.Add(new OrderItem(product, line.Quantity)
            {
                UnitPrice = line.UnitPrice
            });
        }

        return items;
    }

    private string NextConfirmationNumber(DateTime placedAt)
    {
        string prefix = $"OBB-{placedAt:yyMMdd}-";
        int next = 1;

        while (_store.Orders.Any(order =>
            string.Equals(
                order.ConfirmationNumber,
                $"{prefix}{next:000}",
                StringComparison.OrdinalIgnoreCase)))
        {
            next++;
        }

        return $"{prefix}{next:000}";
    }

    private static void ValidateContact(string name, string phone)
    {
        if (string.IsNullOrWhiteSpace(name) ||
            name.Trim().Length > 100)
        {
            throw new ArgumentException(
                "Enter your full name using 100 characters or fewer.");
        }

        if (string.IsNullOrWhiteSpace(phone))
            throw new ArgumentException("Enter your phone number.");

        int digits = phone.Count(char.IsAsciiDigit);

        if (digits < 7 || digits > 15 ||
            phone.Any(character =>
                !char.IsAsciiDigit(character) &&
                !" +-().".Contains(character)))
        {
            throw new ArgumentException(
                "Enter a phone number with 7 to 15 digits.");
        }
    }

    private static decimal RoundMoney(decimal amount) =>
        Math.Round(amount, 2, MidpointRounding.AwayFromZero);
}