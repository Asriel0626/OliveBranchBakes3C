using OliveBranchBakes.Navigation;
using OliveBranchBakes.Data;
using OliveBranchBakes.Forms;
using System.Globalization;

namespace OliveBranchBakes;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        // Keep customer-facing currency and dates consistent across Windows regional settings.
        CultureInfo us = CultureInfo.GetCultureInfo("en-US");
        CultureInfo.DefaultThreadCurrentCulture = us;
        CultureInfo.DefaultThreadCurrentUICulture = us;
        Thread.CurrentThread.CurrentCulture = us;
        Thread.CurrentThread.CurrentUICulture = us;
        ApplicationConfiguration.Initialize();
        try
        {
            AppData.Initialize();
            Application.Run(new BakeryMainForm());
        }
        catch (Exception ex)
        {
            try
            {
                string location = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "OliveBranchBakes", "startup-error.txt");
                Directory.CreateDirectory(Path.GetDirectoryName(location)!);
                File.WriteAllText(location, ex.ToString());
            }
            catch { }
            EnglishDialog.Show("Cannot open saved bakery data:\n\n" + ex.Message +
                "\n\nPlease check your saved bakery data files.",
                "Olive Branch Bakes – Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
