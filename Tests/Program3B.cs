using OliveBranchBakes.Models;
using OliveBranchBakes.Services;

int passed = 0;
void Check(bool condition, string name)
{
    if (!condition) throw new Exception("FAIL: " + name);
    passed++;
    Console.WriteLine("PASS: " + name);
}
void Throws<T>(Action action, string name) where T : Exception
{
    try { action(); }
    catch (T) { Check(true, name); return; }
    throw new Exception("FAIL: " + name);
}

var cart = new ShoppingCartService();
var bread = new BakeryProduct("BR001", "Sourdough loaf", "Breads", "Rustic loaf", 7.50m);
var cookie = new BakeryProduct("CO001", "Chocolate chip cookie", "Cookies", "Cookie", 2.25m);
Check(cart.Items.Count == 0 && cart.Subtotal == 0m, "Empty cart starts at zero");
cart.Add(bread);
Check(cart.ItemCount == 1 && cart.Subtotal == 7.50m, "Add one loaf");
cart.Add(bread, 2);
Check(cart.Items.Count == 1 && cart.ItemCount == 3 && cart.Subtotal == 22.50m,
    "Duplicate product merges into one line");
cart.Add(cookie, 2);
Check(cart.Items.Count == 2 && cart.Subtotal == 27.00m, "Subtotal across products");
cart.SetQuantity("BR001", 4);
Check(cart.ItemCount == 6 && cart.Subtotal == 34.50m, "Change quantity updates subtotal");
cart.Remove("CO001");
Check(cart.Items.Count == 1 && cart.Subtotal == 30.00m, "Removing a line recalculates subtotal");
Throws<ArgumentOutOfRangeException>(() => cart.Add(cookie, 0), "Block zero quantity");
Throws<ArgumentOutOfRangeException>(() => cart.Add(cookie, 100), "Block excess quantity");
Throws<ArgumentOutOfRangeException>(() => cart.SetQuantity("BR001", 0), "Block zero edited quantity");
cart.SetQuantity("BR001", 99);
Throws<InvalidOperationException>(() => cart.Add(bread), "Block adding beyond max quantity");
Check(cart.Items.Single().Quantity == 99, "Rejected add leaves cart unchanged");
cart.Clear();
Check(cart.Items.Count == 0 && cart.Subtotal == 0m, "Clear cart resets subtotal");

var seasonal = VariantRules.SeasonalProduct('3');
cart.SelectMenuDate(new DateTime(2026, 10, 31));
Throws<InvalidOperationException>(() => cart.Add(seasonal), "319 seasonal pie is unavailable October 31");
cart.SelectMenuDate(new DateTime(2026, 11, 1));
cart.Add(seasonal);
Check(cart.ItemCount == 1 && cart.Subtotal == 21m, "319 pie is available November 1");
Check(cart.SelectMenuDate(new DateTime(2027, 1, 1)) == 1 && cart.ItemCount == 0,
    "Out-of-season item is removed when menu date changes");
cart.SelectMenuDate(new DateTime(2026, 11, 2));
cart.Add(seasonal);
Check(cart.SyncWithMenu(new [] { bread, cookie }) == 1 && cart.ItemCount == 0,
    "Changing catalog removes obsolete cart items");
var crossYear = VariantRules.SeasonalProduct('4');
Check(crossYear.IsAvailableOn(new DateTime(2027, 1, 5)) &&
    !crossYear.IsAvailableOn(new DateTime(2027, 1, 6)), "Season spanning New Year is handled");
cart.Add(bread);
bread.Price = 15m;
Check(cart.Subtotal == 7.50m, "Menu price changes do not change an existing cart line");
Console.WriteLine($"{passed} Phase 3B checks passed.");
