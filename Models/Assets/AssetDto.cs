namespace IncidentTrackerUI.Models.Assets;

/// <summary>Shape returned by GET /api/Assets.</summary>
public class AssetDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public AssetType Type { get; set; }
    public string? Location { get; set; }
    public DateTime? InstalledAt { get; set; }
}
