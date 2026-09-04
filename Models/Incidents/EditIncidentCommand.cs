using System.ComponentModel.DataAnnotations;

namespace IncidentTrackerUI.Models.Incidents;

/// <summary>
/// Title/description-only edit model for the Incidents UI. The backend does not yet expose a
/// PUT /api/Incidents/{id} endpoint, so this model backs the Edit modal's form only — saving
/// currently shows a "Coming soon" toast instead of calling the API. Asset is deliberately not
/// editable here (assets are immutable per incident once reported).
/// </summary>
public class EditIncidentCommand
{
    [Required]
    public string? Title { get; set; }

    public string? Description { get; set; }
}
