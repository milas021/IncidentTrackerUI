namespace IncidentTrackerUI.Models.Incidents;

/// <summary>Body for PUT /api/Incidents/{id}/Acknowledge — the "approve/confirm" action.</summary>
public class AcknowledgeIncidentCommand
{
    public IncidentPriority Priority { get; set; }

    public string? Description { get; set; }
}
