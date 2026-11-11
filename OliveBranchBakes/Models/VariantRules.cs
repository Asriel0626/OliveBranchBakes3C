namespace OliveBranchBakes.Models;

/// <summary>Defines seasonal products and order rule labels.</summary>
public static class VariantRules
{
    private static readonly string[] SeasonalNames =
    {
        "Apple cider donut each", "Pumpkin swirl bread loaf", "Pecan pie 9 inch",
        "Sweet potato pie 9 inch", "Gingerbread loaf", "Cranberry orange scone each",
        "Peppermint brownie each", "King cake serves 12", "Maple pecan sticky bun each",
        "Honey lavender shortbread 6 pack"
    };
    private static readonly string[] SeasonalDescriptions =
    {
        "Apple cider donut with cinnamon sugar", "Pumpkin bread with a swirl of spices",
        "Pecan pie with a buttery filling", "Sweet potato pie with warm spices",
        "Classic gingerbread loaf", "Cranberry orange scone",
        "Peppermint chocolate brownie", "King cake with a sweet glaze",
        "Maple pecan sticky bun", "Honey lavender shortbread cookies"
    };
    private static readonly decimal[] SeasonalPrices =
        { 1.75m, 8.50m, 24m, 21m, 9.25m, 3.25m, 3.50m, 32m, 4.25m, 11m };
    private static readonly (int, int, int, int)[] Seasons =
    {
        (9,15,11,30), (10,1,11,30), (11,1,12,31), (11,1,12,31),
        (11,15,1,5), (11,1,1,15), (12,1,12,31), (1,6,3,4),
        (10,15,12,31), (10,1,12,31)
    };
    private static int Digit(char c) => c >= '0' && c <= '9' ? c - '0' : throw new ArgumentException("Use a digit 0–9.");
    public static bool IsValidDigits(string? text) => text is { Length: 3 } && text.All(char.IsAsciiDigit);
    public static string SeasonalName(char digit) => SeasonalNames[Digit(digit)];
    public static string OperationsLabel(char digit) => (Digit(digit) / 2 + 1) switch
    {
        1 => "O1 Pie capacity", 2 => "O2 Lead times", 3 => "O3 Pickup slots",
        4 => "O4 Custom cakes", _ => "O5 Quantity limits"
    };
    public static string PricingLabel(char digit) => (Digit(digit) / 2 + 1) switch
    {
        1 => "P1 Baker's dozen", 2 => "P2 Loyalty", 3 => "P3 Bread-and-butter pair",
        4 => "P4 Volume tiers", _ => "P5 Plan ahead"
    };
    public static BakeryProduct SeasonalProduct(char digit)
    {
        int i = Digit(digit);
        var season = Seasons[i];
        string category = i switch { 1 or 4 => "Breads", 2 or 3 => "Pies", 7 => "Cakes", 5 or 8 => "Pastries", _ => "Cookies" };
        return new BakeryProduct("SEASON-" + i, SeasonalNames[i], category,
            SeasonalDescriptions[i], SeasonalPrices[i])
        {
            IsSeasonal = true,
            SeasonStartMonth = season.Item1, SeasonStartDay = season.Item2,
            SeasonEndMonth = season.Item3, SeasonEndDay = season.Item4
        };
    }
}
