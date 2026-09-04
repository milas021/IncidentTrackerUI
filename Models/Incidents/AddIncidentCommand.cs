using System.ComponentModel.DataAnnotations;

namespace IncidentTrackerUI.Models.Incidents;

/// <summary>Body for POST /api/Incidents.</summary>
public class AddIncidentCommand
{
    [Required]
    public Guid AssetId { get; set; }

    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }
}
