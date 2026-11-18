
using OliveBranchBakes.Models;
using OliveBranchBakes.Services;

var settings = new BakerySettings();
IPricingService pricing = new PlanAheadPricingService(settings);

var bread = new BakeryProduct(
    "BR001", "Sourdough loaf", "Breads",
    "Rustic loaf", 7.50m);

var cookie = new BakeryProduct(
    "CO001", "Chocolate chip cookie", "Cookies",
    "Chocolate chip cookie", 2.25m);

var pie = new BakeryProduct(
    "PI001", "Apple pie 9 inch", "Pies",
    "Apple pie", 22.00m);

BakeryProduct[] products = { bread, cookie, pie };

DateTime placedAt = new DateTime(2026, 11, 17, 10, 0, 0);

PricingResult Quote(DateTime pickupAt, params OrderItem[] items)
{
    return pricing.Calculate(
        items, products, placedAt, pickupAt);
}

decimal RoundMoney(decimal amount)
{
    return Math.Round(
        amount, 2, MidpointRounding.AwayFromZero);
}

void Check(string testName, decimal actual, decimal expected)
{
    if (actual != expected)
    {
        throw new Exception(
            $"FAIL {testName}: Expected {expected}, got {actual}");
    }

    Console.WriteLine($"PASS {testName}: {actual:F2}");
}

// T1 - Normal order, pickup three days later
var t1 = Quote(
    placedAt.AddDays(3),
    new OrderItem(bread, 2),
    new OrderItem(cookie, 6),
    new OrderItem(pie, 1));

Check("T1 Subtotal", t1.Subtotal, 50.50m);
Check("T1 Discount", t1.Discount, 0m);
Check("T1 Total", RoundMoney(t1.Total), 54.79m);

// T2 - One minute before seven-day threshold
var t2 = Quote(
    placedAt.AddDays(7).AddMinutes(-1),
    new OrderItem(pie, 1));

Check("T2 Discount", t2.Discount, 0m);
Check("T2 Total", RoundMoney(t2.Total), 23.87m);

// T3 - Exactly seven days ahead
var t3 = Quote(
    placedAt.AddDays(7),
    new OrderItem(pie, 1));

Check("T3 Discount", t3.Discount, 0.50m);
Check("T3 Total", RoundMoney(t3.Total), 23.33m);

// T4 - Three pies, eight days ahead
var t4 = Quote(
    placedAt.AddDays(8),
    new OrderItem(pie, 3));

Check("T4 Discount", t4.Discount, 1.50m);
Check("T4 Total", RoundMoney(t4.Total), 69.98m);

// Additional boundary test - Just under 48 hours
var rush = Quote(
    placedAt.AddHours(48).AddMinutes(-1),
    new OrderItem(bread, 1));

Check("Rush Fee Under 48h", rush.Fees, 5.00m);
Check("Rush Total", RoundMoney(rush.Total), 13.56m);

// Additional boundary test - Exactly 48 hours
var normal = Quote(
    placedAt.AddHours(48),
    new OrderItem(bread, 1));

Check("Rush Fee At 48h", normal.Fees, 0m);
Check("Normal Total", RoundMoney(normal.Total), 8.14m);


//
// Tests matching the original Excel test table.
//

var excelCake = new BakeryProduct(
    "CA001", "Custom decorated cake", "Cakes",
    "Decorated cake", 45.00m);

var excelSweetPie = new BakeryProduct(
    "SEASON-3", "Sweet potato pie 9 inch", "Pies",
    "Seasonal sweet potato pie", 21.00m)
{
    IsSeasonal = true,
    SeasonStartMonth = 11,
    SeasonStartDay = 1,
    SeasonEndMonth = 12,
    SeasonEndDay = 31
};

var excelMuffin = new BakeryProduct(
    "MU001", "Blueberry muffin", "Muffins",
    "Blueberry muffin", 3.00m);

BakeryProduct[] excelProducts =
{
    bread, cookie, pie,
    excelCake, excelSweetPie, excelMuffin
};

PricingResult ExcelQuote(
    DateTime orderDate,
    DateTime pickupDate,
    params OrderItem[] cart)
{
    return pricing.Calculate(
        cart, excelProducts, orderDate, pickupDate);
}

void ExcelCheck(
    string name,
    PricingResult result,
    decimal expectedSubtotal,
    decimal expectedDiscount,
    decimal expectedFees,
    decimal expectedTotal)
{
    Check(name + " Subtotal",
        result.Subtotal, expectedSubtotal);

    Check(name + " Discount",
        result.Discount, expectedDiscount);

    Check(name + " Fees",
        result.Fees, expectedFees);

    Check(name + " Total",
        RoundMoney(result.Total), expectedTotal);
}

// T1 - November 2 to November 5
ExcelCheck("Excel T1",
    ExcelQuote(
        new DateTime(2026, 11, 2, 10, 0, 0),
        new DateTime(2026, 11, 5, 10, 0, 0),
        new OrderItem(bread, 2),
        new OrderItem(cookie, 6),
        new OrderItem(pie, 1)),
    50.50m, 0m, 0m, 54.79m);

// T2 - One minute short of seven days
ExcelCheck("Excel T2",
    ExcelQuote(
        new DateTime(2026, 11, 3, 10, 1, 0),
        new DateTime(2026, 11, 10, 10, 0, 0),
        new OrderItem(pie, 1),
        new OrderItem(cookie, 1)),
    24.25m, 0m, 0m, 26.31m);

// T3 - Exactly seven days
ExcelCheck("Excel T3",
    ExcelQuote(
        new DateTime(2026, 11, 3, 10, 0, 0),
        new DateTime(2026, 11, 10, 10, 0, 0),
        new OrderItem(pie, 1),
        new OrderItem(cookie, 1)),
    24.25m, 0.50m, 0m, 25.77m);

// T4 - Two pies and one cake
ExcelCheck("Excel T4",
    ExcelQuote(
        new DateTime(2026, 11, 2, 10, 0, 0),
        new DateTime(2026, 11, 12, 10, 0, 0),
        new OrderItem(pie, 2),
        new OrderItem(excelCake, 1)),
    89.00m, 1.50m, 0m, 94.94m);

// T5 - Same pricing for guest and signed-in customer
var excelT5Guest = ExcelQuote(
    new DateTime(2026, 11, 3, 10, 0, 0),
    new DateTime(2026, 11, 11, 10, 0, 0),
    new OrderItem(excelSweetPie, 1),
    new OrderItem(excelMuffin, 1));

var excelT5SignedIn = ExcelQuote(
    new DateTime(2026, 11, 3, 10, 0, 0),
    new DateTime(2026, 11, 11, 10, 0, 0),
    new OrderItem(excelSweetPie, 1),
    new OrderItem(excelMuffin, 1));

ExcelCheck("Excel T5-G",
    excelT5Guest,
    24.00m, 0.50m, 0m, 25.50m);

ExcelCheck("Excel T5-S",
    excelT5SignedIn,
    24.00m, 0.50m, 0m, 25.50m);

Check("Excel T5 Same Total",
    excelT5Guest.Total,
    excelT5SignedIn.Total);

// T11 - One minute short of 48 hours
ExcelCheck("Excel T11",
    ExcelQuote(
        new DateTime(2026, 11, 4, 10, 1, 0),
        new DateTime(2026, 11, 6, 10, 0, 0),
        new OrderItem(pie, 1),
        new OrderItem(cookie, 1)),
    24.25m, 0m, 5.00m, 31.74m);

// T12 - Exactly 48 hours
ExcelCheck("Excel T12",
    ExcelQuote(
        new DateTime(2026, 11, 4, 10, 0, 0),
        new DateTime(2026, 11, 6, 10, 0, 0),
        new OrderItem(pie, 1),
        new OrderItem(cookie, 1)),
    24.25m, 0m, 0m, 26.31m);

Console.WriteLine();
Console.WriteLine("Excel pricing cases completed.");


Console.WriteLine();
Console.WriteLine("All Phase 3D pricing checks passed.");
