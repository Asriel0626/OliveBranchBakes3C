namespace OliveBranchBakes.Models;

/// <summary>Customer's order and immutable-at-order-time item-price snapshots.</summary>
public sealed class BakeryOrder
{
    public string ConfirmationNumber { get; set; } = "";
    public string? CustomerId { get; set; }
    public string ContactName { get; set; } = "";
    public string ContactPhone { get; set; } = "";
    public DateTime PlacedAt { get; set; }
    public DateTime PickupAt { get; set; }
    public OrderStatus Status { get; set; } = OrderStatus.Received;
    public string Notes { get; set; } = "";
    public List<OrderItem> Items { get; set; } = new();
    public decimal Discount { get; set; }
    public decimal Fees { get; set; }
    public decimal Tax { get; set; }
    public decimal Subtotal => Items.Sum(line => line.LineTotal);
    public decimal Total => Subtotal - Discount + Fees + Tax;

    public BakeryOrder() { }
    public BakeryOrder(string number, string? customerId, string name, string phone,
        DateTime placedAt, DateTime pickupAt, IEnumerable<OrderItem> items)
    {
        ConfirmationNumber = number;
        CustomerId = customerId; ContactName = name.Trim(); ContactPhone = phone.Trim();
        PlacedAt = placedAt; PickupAt = pickupAt; Items = items.ToList();
        Validate();
    }

    public void Validate()
    {
        if (string.IsNullOrWhiteSpace(ConfirmationNumber) || string.IsNullOrWhiteSpace(ContactName)
            || PickupAt <= PlacedAt || Items is null || Items.Count == 0)
            throw new InvalidDataException("An order has missing contact, pickup or cart information.");
        foreach (OrderItem item in Items) item.Validate();
        if (Discount < 0 || Fees < 0 || Tax < 0)
            throw new InvalidDataException("An order has an invalid adjustment.");
    }
}
