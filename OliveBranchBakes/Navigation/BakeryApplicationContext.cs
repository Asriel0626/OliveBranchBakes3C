namespace OliveBranchBakes.Navigation;

internal static class BakeryApplicationContext
{
    internal static void Navigate(Page destination)
    {
        if (BakeryMainForm.Current is not { IsDisposed: false } main)
            throw new InvalidOperationException("The main window is not available.");
        main.ShowPage(destination);
    }
}
