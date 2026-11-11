using OliveBranchBakes.Navigation;
using System.ComponentModel;
using System.Drawing;

namespace OliveBranchBakes.Forms;

/// <summary>Administrator sign-in screen.</summary>
public partial class AdministratorLoginForm : Form
{
    public AdministratorLoginForm()
    {
        InitializeComponent();
        LoadPreviewImages();
    }

    private void Navigate_Click(object? sender, EventArgs e)
    {
        if (sender is Button button && button.Tag is string target &&
            Enum.TryParse<Page>(target, out Page page))
        {
            BakeryApplicationContext.Navigate(page);
        }
    }

    private void PreviewOnly_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            "This feature is not available yet.",
            "Olive Branch Bakes",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void ProjectInfo_Click(object? sender, EventArgs e)
    {
        EnglishDialog.Show(
            "Project: Olive Branch Bakes\nStudent: EnYan Chen\nCourse: CS3388 Object-Oriented Programming\n" +
            "Application: menu and order record storage\n" +
            "Saved records are available. Account and checkout features are not implemented yet.",
            "About the project", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void LoadPreviewImages()
    {
        // No images on this page.
    }
}
