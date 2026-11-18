
using OliveBranchBakes.Models;
using OliveBranchBakes.Services;

var settings = new BakerySettings();
var pickupService = new PickupService(settings);

var pie = new BakeryProduct(
    "PI001",
    "Apple pie 9 inch",
    "Pies",
    "Traditional apple pie",
    22.00m);

BakeryProduct[] products = { pie };

// Fixed dates keep the tests repeatable.
DateTime placedAt = new(2026, 11, 3, 10, 0, 0);
DateTime pickupAt = new(2026, 11, 6, 10, 0, 0);

int orderNumber = 0;

BakeryOrder ExistingOrder(
    int quantity,
    DateTime date,
    OrderStatus status = OrderStatus.Received)
{
    return new BakeryOrder(
        $"OBB-261117-{++orderNumber:000}",
        null,
        "Test Customer",
        "555-0101",
        placedAt,
        date,
        new[] { new OrderItem(pie, quantity) })
    {
        Status = status
    };
}

void Check(bool condition, string testName)
{
    if (!condition)
        throw new Exception($"FAIL {testName}");

    Console.WriteLine($"PASS {testName}");
}

void ExpectBlocked(
    IReadOnlyCollection<BakeryOrder> orders,
    int quantity,
    string testName,
    string expectedMessage)
{
    try
    {
        pickupService.Validate(
            new[] { new OrderItem(pie, quantity) },
            products,
            orders,
            placedAt,
            pickupAt);
    }
    catch (InvalidOperationException ex)
    {
        Check(
            ex.Message.Contains(expectedMessage),
            testName);

        return;
    }

    throw new Exception(
        $"FAIL {testName}: Order was not blocked.");
}

// T6: 11 reserved pies + 1 new pie = 12.
var elevenPies = new[]
{
    ExistingOrder(11, pickupAt)
};

Check(
    pickupService.GetRemainingPies(
        elevenPies, products, pickupAt) == 1,
    "T6 Remaining capacity is 1");

pickupService.Validate(
    new[] { new OrderItem(pie, 1) },
    products,
    elevenPies,
    placedAt,
    pickupAt);

Console.WriteLine("PASS T6 Exactly 12 pies allowed");

// T7: 12 reserved pies + 1 new pie = 13.
var twelvePies = new[]
{
    ExistingOrder(12, pickupAt)
};

Check(
    pickupService.GetRemainingPies(
        twelvePies, products, pickupAt) == 0,
    "T7 Remaining capacity is 0");

ExpectBlocked(
    twelvePies,
    1,
    "T7 Thirteenth pie blocked",
    "Only 0 pies remaining");

// Extra: 11 reserved pies + 2 new pies = 13.
ExpectBlocked(
    elevenPies,
    2,
    "Two pies exceed remaining capacity",
    "Your cart contains 2");

// Extra: Other dates should not affect capacity.
var otherDateOrders = new[]
{
    ExistingOrder(12, pickupAt.AddDays(1))
};

Check(
    pickupService.GetRemainingPies(
        otherDateOrders, products, pickupAt) == 12,
    "Other date does not affect capacity");

// Extra: Cancelled orders should not use capacity.
var cancelledOrders = new[]
{
    ExistingOrder(
        12,
        pickupAt,
        OrderStatus.Cancelled)
};

Check(
    pickupService.GetRemainingPies(
        cancelledOrders, products, pickupAt) == 12,
    "Cancelled orders release capacity");

// Extra: Capacity adds pies from multiple orders.
var multipleOrders = new[]
{
    ExistingOrder(5, pickupAt),
    ExistingOrder(6, pickupAt)
};

Check(
    pickupService.GetRemainingPies(
        multipleOrders, products, pickupAt) == 1,
    "Multiple orders count together");

Console.WriteLine();
Console.WriteLine("All O1 capacity tests passed.");
