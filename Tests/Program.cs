using OliveBranchBakes.Data;
using OliveBranchBakes.Models;
using OliveBranchBakes.Services;

// Basic data checks. Run: dotnet run --project Tests/Phase3ADataTests.csproj
string path = Path.Combine(Path.GetTempPath(), "obb-3a-smoke-" + Guid.NewGuid().ToString("N"));
int checks = 0;
void Check(bool value, string message)
{
    if (!value) throw new Exception("FAIL: " + message);
    Console.WriteLine("PASS: " + message);
    checks++;
}
try
{
    var store = new DataStore(path);
    Check(store.Products.Count == 16 && store.Products.Count(x => !x.IsSeasonal) == 15, "15 regular plus one seasonal item");
    Check(store.Settings.SeasonalItemLabel == "Sweet potato pie 9 inch" && store.Settings.OperationsLabel == "O1 Pie capacity" && store.Settings.PricingLabel == "P5 Plan ahead", "assigned O1/P5 labels initialized");
    Check(store.Products.Single(x => x.IsSeasonal).Price == 21m && store.Products.Single(x => x.IsSeasonal).IsAvailableOn(new DateTime(2026,11,1)) && !store.Products.Single(x => x.IsSeasonal).IsAvailableOn(new DateTime(2026,10,31)), "assigned seasonal pie price and dates");
    Check(store.Categories.Count >= 4, "four or more menu categories");
    Check(store.Customers.Count == 3, "three seeded customers");
    Check(store.Orders.Count == 8 && store.Orders.Select(x => x.PickupAt.Date).Distinct().Count() >= 3,
        "eight orders across three or more pickup dates");
    Check(store.Orders.All(x => x.Status == OrderStatus.Received), "new sample orders are Received");
    Check(store.Products.Single(x => x.Id == "BR001").Price == 7.50m, "baseline sourdough price");
    Check(store.Customers[0].VerifyPassword("Demo12345") &&
        !store.Customers[0].VerifyPassword("Wrong12345"), "salted password hash verification");
    var order = store.AddSampleOrder();
    Check(store.Orders.Count == 9 && File.Exists(Path.Combine(path, "orders.json")), "sample order written to JSON");
    var reopened = new DataStore(path);
    Check(reopened.Orders.Count == 9 && reopened.Orders.Any(x => x.ConfirmationNumber == order.ConfirmationNumber),
        "order survives DataStore reconstruction");
    decimal savedPrice = reopened.Orders.Last().Items[0].UnitPrice;
    reopened.Products.Single(x => x.Id == "BR001").Price = 15m;
    reopened.SaveAll();
    var reopenPrice = new DataStore(path);
    Check(reopenPrice.Orders.Last().Items[0].UnitPrice == savedPrice,
        "historical order item price unchanged after catalog update");
    reopenPrice.SelectVariant("444");
    var seasonal = new DataStore(path).Products.Single(x => x.IsSeasonal);
    Check(seasonal.Name == "Gingerbread loaf" && seasonal.IsAvailableOn(new DateTime(2027, 1, 3)) &&
        !seasonal.IsAvailableOn(new DateTime(2027, 1, 6)), "variant persisted and year-crossing season checked");
    var catalog = new CatalogService(reopenPrice);
    Check(catalog.AvailableOn(new DateTime(2027, 1, 3)).Count > 0,
        "CatalogService can filter products");
    // Each category should return matching menu items only.
    DateTime inSeason = new DateTime(2026, 12, 1);
    foreach (BakeryCategory category in reopenPrice.Categories)
    {
        var filtered = catalog.AvailableOn(inSeason, category.Id);
        Check(filtered.All(p => p.CategoryId.Equals(category.Id, StringComparison.OrdinalIgnoreCase)),
            "filter " + category.Name + " shows only matching menu items");
    }
    Check(catalog.AvailableOn(inSeason, "Breads").Any(p => p.Id == "BR001"),
        "Breads includes sourdough loaf");
    Check(catalog.AvailableOn(inSeason, "Cookies").Any(p => p.Id == "CO001"),
        "Cookies includes chocolate chip cookie");
    Check(catalog.AvailableOn(inSeason, "Muffins").Any(p => p.Id == "MU001"),
        "Muffins includes blueberry muffin");
    Check(catalog.AvailableOn(inSeason, "Pastries").Any(p => p.Id == "PA001"),
        "Pastries includes cinnamon roll");
    Check(catalog.AvailableOn(inSeason, "Pies").Any(p => p.Id == "PI001"),
        "Pies includes apple pie");
    Check(catalog.AvailableOn(inSeason, "Cakes").Any(p => p.Id == "CA001"),
        "Cakes includes custom cake");
    Check(catalog.AvailableOn(inSeason, "Extras").Any(p => p.Id == "EX001"),
        "Extras includes honey butter");
    // Variant 444 = gingerbread loaf, Nov 15 to Jan 5.
    Check(catalog.AvailableOn(new DateTime(2026, 12, 1)).Any(p => p.IsSeasonal),
        "seasonal item appears during its availability window");
    Check(!catalog.AvailableOn(new DateTime(2026, 10, 1)).Any(p => p.IsSeasonal),
        "seasonal item is hidden outside its availability window");
    Check(catalog.AvailableOn(new DateTime(2026, 10, 1)).Count == 15,
        "All baked goods shows 15 regular items when the seasonal item is unavailable");
    Console.WriteLine($"All {checks} smoke checks passed.");
}
finally
{
    if (Directory.Exists(path)) Directory.Delete(path, true);
}
