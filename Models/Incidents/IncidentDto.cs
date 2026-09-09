using IncidentTrackerUI.Models.Assets;
using IncidentTrackerUI.Models.WorkOrders;

namespace IncidentTrackerUI.Models.Incidents;

/// <summary>Shape returned by GET /api/Incidents and GET /api/Incidents/{id}.</summary>
public class IncidentDto
{
    public Guid Id { get; set; }
    public Guid AssetId { get; set; }
    public AssetDto? Asset { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public IncidentPriority Priority { get; set; }
    public IncidentStatus Status { get; set; }
    public DateTime ReportedAt { get; set; }
    public DateTime? AcknowledgedAt { get; set; }
    public DateTime? ResolvedAt { get; set; }
    public DateTime? ClosedAt { get; set; }
    public List<WorkOrderDto>? WorkOrders { get; set; }
}
