using OliveBranchBakes.Models;

namespace OliveBranchBakes.Data;

/// <summary>Initial menu, customer, and order records.</summary>
public static class SeedData
{
    public static List<BakeryCategory> Categories() => new()
    {
        new("Breads", "Breads", "Slow-fermented loaves and bakery breads"),
        new("Cookies", "Cookies", "Small batch cookies"),
        new("Muffins", "Muffins", "Morning muffins"),
        new("Pastries", "Pastries", "Handcrafted pastries"),
        new("Pies", "Pies", "Holiday and everyday pies"),
        new("Cakes", "Cakes", "Celebration cakes"),
        new("Extras", "Extras", "Jars, toppings and accompaniments")
    };

    public static List<BakeryProduct> Products(BakerySettings settings) => new()
    {
        // Required menu items and their prices.
        new("BR001", "Sourdough loaf", "Breads", "Slow-fermented rustic loaf", 7.50m),
        new("CO001", "Chocolate chip cookie", "Cookies", "Classic chocolate chip cookie", 2.25m),
        new("MU001", "Blueberry muffin", "Muffins", "Fresh blueberry muffin", 3.00m),
        new("PA001", "Cinnamon roll", "Pastries", "Cinnamon swirl with glaze", 3.75m),
        new("PI001", "Apple pie 9 inch", "Pies", "Traditional 9-inch apple pie", 22.00m),
        new("CA001", "Custom decorated cake", "Cakes", "Made-to-order decorated cake", 45.00m),
        new("EX001", "Honey butter jar", "Extras", "Honey butter spread", 5.00m),
        new("BR002", "Brioche loaf", "Breads", "Soft buttery brioche", 8.00m),
        new("BR003", "Whole wheat loaf", "Breads", "Whole grain loaf", 7.00m),
        new("CO002", "Oatmeal cookie", "Cookies", "Oats and cinnamon", 2.50m),
        new("CO003", "Sugar cookie", "Cookies", "Vanilla sugar cookie", 2.00m),
        new("MU002", "Lemon poppy muffin", "Muffins", "Lemon with poppy seeds", 3.25m),
        new("PA002", "Croissant", "Pastries", "Buttery flaky pastry", 3.50m),
        new("PI002", "Cherry pie 9 inch", "Pies", "Sweet-tart cherry pie", 24.00m),
        new("CA002", "Vanilla cake", "Cakes", "Classic vanilla layer cake", 38.00m),
        VariantRules.SeasonalProduct(settings.VariantDigits[0])
    };

    public static List<Customer> Customers() => new()
    {
        // Sample accounts use hashed passwords when saved.
        new("C001", "Alex Morgan", "alex.demo@example.test", "555-0101", "Demo12345"),
        new("C002", "Jordan Lee", "jordan.demo@example.test", "555-0102", "Demo12345"),
        new("C003", "Taylor Rivera", "taylor.demo@example.test", "555-0103", "Demo12345")
    };

    public static List<BakeryOrder> Orders(List<BakeryProduct> products, List<Customer> customers, decimal taxRate)
    {
        BakeryProduct Find(string id) => products.Single(item => item.Id == id);
        var result = new List<BakeryOrder>();
        DateTime now = DateTime.Now;

        int[] offsets = { 3, 3, 5, 5, 8, 8, 12, 12 };
        for (int i = 0; i < offsets.Length; i++)
        {
            var customer = customers[i % customers.Count];
            DateTime pickup = DateTime.Today.AddDays(offsets[i]).AddHours(10);
            // Skip holidays when choosing a pickup date.
            while (pickup.Month == 12 && pickup.Day == 25 ||
                (pickup.Month == 11 && pickup.DayOfWeek == DayOfWeek.Thursday && pickup.Day >= 22 && pickup.Day <= 28))
                pickup = pickup.AddDays(1);
            var order = new BakeryOrder($"OBB-{now:yyMMdd}-{i + 1:000}", customer.Id, customer.FullName,
                customer.Phone, now.AddMinutes(-8 - i), pickup,
                new[]
                {
                    new OrderItem(Find(i % 2 == 0 ? "BR001" : "CO001"), i % 3 + 1),
                    new OrderItem(Find(i % 2 == 0 ? "PI001" : "MU001"), 1)
                });
            // Record the sample order's basic tax amount.
            order.Tax = Math.Round(order.Subtotal * taxRate, 2, MidpointRounding.AwayFromZero);
            result.Add(order);
        }
        return result;
    }
}
