
using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using OliveBranchBakes.Services;

int passed = 0;

void Check(bool condition, string name)
{
    if (!condition)
        throw new Exception("FAIL: " + name);

    passed++;
    Console.WriteLine("PASS " + name);
}

// Use a separate folder so real customer data stays safe.
string folder = Path.Combine(
    Path.GetTempPath(),
    "obb-3d-persistence-" + Guid.NewGuid().ToString("N"));

try
{
    // Step 1: Initialize data and services.
    var store = new DataStore(folder);
    var accounts = new CustomerAccountService(store);

    IPricingService pricing =
        new PlanAheadPricingService(store.Settings);

    SchedulingService scheduling =
        new PickupService(store.Settings);

    var orderService = new OrderService(
        store, pricing, scheduling, accounts);

    int initialOrderCount = store.Orders.Count;

    // Step 2: Create an account.
    var customer = accounts.CreateAccount(
        "Persistence Tester",
        "persistence.test@example.com",
        "555-0104",
        "Test12345");

    Check(
        File.Exists(Path.Combine(folder, "customers.json")),
        "Customer JSON file exists");

    Check(
        accounts.CurrentCustomer?.Id == customer.Id,
        "New customer is signed in");

    // Step 3: Prepare a valid pickup date.
    DateTime pickupAt = DateTime.Now.AddDays(4);

    while (
        (pickupAt.Month == 12 && pickupAt.Day == 25) ||
        (pickupAt.Month == 11 &&
         pickupAt.DayOfWeek == DayOfWeek.Thursday &&
         pickupAt.Day >= 22 && pickupAt.Day <= 28))
    {
        pickupAt = pickupAt.AddDays(1);
    }

    // Step 4: Add a pie and place a real service order.
    var pie = store.Products.Single(
        product => product.Id == "PI001");

    var cart = new ShoppingCartService();
    cart.SelectMenuDate(pickupAt.Date);
    cart.Add(pie, 1);

    BakeryOrder order = orderService.PlaceOrder(
        cart,
        customer.FullName,
        customer.Phone,
        pickupAt,
        "Phase 3D persistence test");

    Check(
        order.Status == OrderStatus.Received,
        "New order status is Received");

    Check(
        order.ConfirmationNumber.StartsWith(
            $"OBB-{order.PlacedAt:yyMMdd}-"),
        "Confirmation number format");

    Check(
        order.CustomerId == customer.Id,
        "Order belongs to signed-in customer");

    Check(
        order.Total == 23.87m,
        "Order total is correct");

    Check(
        cart.Items.Count == 0,
        "Cart clears after successful order");

    Check(
        store.Orders.Count == initialOrderCount + 1,
        "Order added to storage");

    Check(
        File.Exists(Path.Combine(folder, "orders.json")),
        "Orders JSON file exists");

    // Step 5: Simulate restarting the application.
    var reopened = new DataStore(folder);

    var savedOrder = reopened.Orders.Single(
        item => item.ConfirmationNumber ==
                order.ConfirmationNumber);

    Check(
        savedOrder.Status == OrderStatus.Received,
        "Order status survives reload");

    Check(
        savedOrder.Total == order.Total,
        "Order total survives reload");

    Check(
        savedOrder.Notes == "Phase 3D persistence test",
        "Order notes survive reload");

    // Step 6: Sign in using reloaded customer data.
    var reopenedAccounts =
        new CustomerAccountService(reopened);

    var signedIn = reopenedAccounts.SignIn(
        "PERSISTENCE.TEST@EXAMPLE.COM",
        "Test12345");

    Check(
        signedIn.Id == customer.Id,
        "Account survives reload");

    Check(
        reopenedAccounts.GetOrderHistory().Any(
            item => item.ConfirmationNumber ==
                    order.ConfirmationNumber),
        "Order appears in customer history");

    // Step 7: Historical order prices must not change.
    decimal originalPrice = savedOrder.Items.Single().UnitPrice;

    reopened.Products.Single(
        product => product.Id == "PI001").Price = 99m;

    reopened.SaveAll();

    var finalReload = new DataStore(folder);

    var finalOrder = finalReload.Orders.Single(
        item => item.ConfirmationNumber ==
                order.ConfirmationNumber);

    Check(
        finalOrder.Items.Single().UnitPrice == originalPrice,
        "Historical item price remains unchanged");

    Check(
        finalOrder.Total == order.Total,
        "Historical order total remains unchanged");

    Console.WriteLine();
    Console.WriteLine(
        $"All {passed} persistence checks passed.");
}
finally
{
    // Remove only this temporary test folder.
    if (Directory.Exists(folder))
        Directory.Delete(folder, true);
}
