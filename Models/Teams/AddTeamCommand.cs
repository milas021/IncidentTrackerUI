using System.ComponentModel.DataAnnotations;

namespace IncidentTrackerUI.Models.Teams;

/// <summary>Body for POST /api/Team.</summary>
public class AddTeamCommand
{
    [Required]
    public string? Name { get; set; }

    public string? Description { get; set; }
}
