using System.ComponentModel.DataAnnotations;

namespace IncidentTrackerUI.Models.Assets;

/// <summary>Body for PUT /api/Assets/{id}.</summary>
public class EditAssetCommand
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Code { get; set; } = string.Empty;

    public AssetType Type { get; set; }

    public string? Location { get; set; }

    public DateTime? InstalledAt { get; set; }
}
