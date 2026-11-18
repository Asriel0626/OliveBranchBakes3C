
using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using OliveBranchBakes.Services;

int passed = 0;

void Check(bool condition, string name)
{
    if (!condition)
        throw new Exception("FAIL " + name);

    passed++;
    Console.WriteLine("PASS " + name);
}

void ExpectBlocked(
    Action action,
    string name,
    string expectedText)
{
    try
    {
        action();
    }
    catch (ArgumentException ex)
    {
        Check(
            ex.Message.Contains(
                expectedText,
                StringComparison.OrdinalIgnoreCase),
            name);
        return;
    }
    catch (InvalidOperationException ex)
    {
        Check(
            ex.Message.Contains(
                expectedText,
                StringComparison.OrdinalIgnoreCase),
            name);
        return;
    }

    throw new Exception(
        "FAIL " + name + ": Operation was not blocked.");
}

string folder = Path.Combine(
    Path.GetTempPath(),
    "obb-3d-validation-" + Guid.NewGuid().ToString("N"));

try
{
    var store = new DataStore(folder);
    var catalog = new CatalogService(store);
    var accounts = new CustomerAccountService(store);

    var pricing = new PlanAheadPricingService(store.Settings);
    var pickupService = new PickupService(store.Settings);

    var pie = store.Products.Single(p => p.Id == "PI001");
    var seasonal = store.Products.Single(
        p => p.Id == "SEASON-3");

    DateTime placed = new(2026, 10, 20, 10, 0, 0);
    DateTime pickup = placed.AddDays(7);

    // T5: Guest and signed-in pricing should match.
    var items = new[] { new OrderItem(pie, 1) };

    var guestPrice = pricing.Calculate(
        items, store.Products, placed, pickup);

    accounts.CreateAccount(
        "Validation Tester",
        "validation@example.com",
        "555-0105",
        "Test12345");

    var signedInPrice = pricing.Calculate(
        items, store.Products, placed, pickup);

    Check(
        accounts.CurrentCustomer is not null,
        "T5 Customer signed in");

    Check(
        guestPrice.Total == signedInPrice.Total &&
        guestPrice.Discount == signedInPrice.Discount,
        "T5 Guest and signed-in pricing match");

    // T8: Seasonal item is available Nov 1 - Dec 31.
    DateTime beforeSeason = new(2026, 10, 31);
    DateTime firstDay = new(2026, 11, 1);
    DateTime afterSeason = new(2027, 1, 1);

    Check(
        !seasonal.IsAvailableOn(beforeSeason),
        "T8 October 31 blocked");

    Check(
        seasonal.IsAvailableOn(firstDay),
        "T8 November 1 allowed");

    Check(
        !seasonal.IsAvailableOn(afterSeason),
        "T8 January 1 blocked");

    Check(
        !catalog.AvailableOn(beforeSeason)
            .Any(p => p.Id == seasonal.Id),
        "T8 Seasonal item hidden in catalog");

    var seasonalCart = new ShoppingCartService();
    seasonalCart.SelectMenuDate(firstDay);
    seasonalCart.Add(seasonal, 1);

    Check(
        seasonalCart.SelectMenuDate(beforeSeason) == 1 &&
        seasonalCart.Items.Count == 0,
        "T8 Seasonal item removed after date change");

    ExpectBlocked(
        () => pickupService.Validate(
            new[] { new OrderItem(seasonal, 1) },
            store.Products,
            Array.Empty<BakeryOrder>(),
            new DateTime(2026, 10, 28, 10, 0, 0),
            beforeSeason.AddHours(10)),
        "T8 Checkout rejects out-of-season item",
        "not available");

    // T9: Empty cart and invalid quantities.
    DateTime t9PlacedAt = new(2026, 11, 3, 10, 0, 0);
DateTime t9PickupAt = new(2026, 11, 6, 10, 0, 0);
    ExpectBlocked(
        () => pickupService.Validate(
            Array.Empty<OrderItem>(),
            store.Products,
            Array.Empty<BakeryOrder>(),
            t9PlacedAt,
            t9PickupAt),
        "T9 Empty cart blocked",
        "Add at least one item");

    var cart = new ShoppingCartService();
    cart.SelectMenuDate(pickup);
    cart.Add(pie, 1);

    ExpectBlocked(
        () => cart.Add(pie, 0),
        "T9 Zero quantity blocked",
        "quantity");

    ExpectBlocked(
        () => cart.SetQuantity(pie.Id, 0),
        "T9 Setting quantity to zero blocked",
        "whole number");

    Check(
        cart.Items.Single().Quantity == 1,
        "T9 Invalid quantity does not change cart");

    // T10: December 25 must be rejected.
    DateTime christmas = new(2026, 12, 25, 10, 0, 0);

    ExpectBlocked(
        () => pickupService.Validate(
            new[] { new OrderItem(pie, 1) },
            store.Products,
            Array.Empty<BakeryOrder>(),
            new DateTime(2026, 12, 20, 10, 0, 0),
            christmas),
        "T10 Christmas pickup blocked",
        "December 25");

    // Extra: Thanksgiving must also be rejected.
    DateTime thanksgiving = new(
        2026, 11, 26, 10, 0, 0);

    ExpectBlocked(
        () => pickupService.Validate(
            new[] { new OrderItem(pie, 1) },
            store.Products,
            Array.Empty<BakeryOrder>(),
            new DateTime(2026, 11, 20, 10, 0, 0),
            thanksgiving),
        "Thanksgiving pickup blocked",
        "Thanksgiving");

    // T12: Duplicate email, wrong password.
    ExpectBlocked(
        () => accounts.CreateAccount(
            "Duplicate Tester",
            "VALIDATION@EXAMPLE.COM",
            "555-0106",
            "Test12345"),
        "T12 Duplicate email blocked",
        "already uses this email");

    accounts.SignOut();

    ExpectBlocked(
        () => accounts.SignIn(
            "validation@example.com",
            "Wrong12345"),
        "T12 Incorrect password blocked",
        "incorrect");

    Check(
        accounts.CurrentCustomer is null,
        "T12 Failed login does not sign in");

    accounts.SignIn(
        "VALIDATION@EXAMPLE.COM",
        "Test12345");

    Check(
        accounts.CurrentCustomer is not null,
        "T12 Email sign-in ignores case");

    Console.WriteLine();
    Console.WriteLine(
        $"All {passed} validation checks passed.");
}
finally
{
    if (Directory.Exists(folder))
        Directory.Delete(folder, true);
}
