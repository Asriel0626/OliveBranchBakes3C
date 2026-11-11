using System.Globalization;

namespace OliveBranchBakes.Forms;

internal static class DisplayFormat
{
    internal static string Usd(decimal amount) =>
        "$" + amount.ToString("N2", CultureInfo.InvariantCulture);

    internal static string PickupTime(DateTime pickup) =>
        pickup.ToString("MM/dd/yyyy hh:mm", CultureInfo.InvariantCulture) +
        (pickup.Hour < 12 ? " AM" : " PM");
}
