namespace OliveBranchBakes.Models;

/// <summary>A menu grouping kept in a separate, serializable data model.</summary>
public sealed class BakeryCategory
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";

    public BakeryCategory() { } // Required by System.Text.Json.

    public BakeryCategory(string id, string name, string description)
    {
        if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("A category needs an ID and name.");
        Id = id.Trim();
        Name = name.Trim();
        Description = description.Trim();
    }
}
