using IncidentTrackerUI.Models.Incidents;
using IncidentTrackerUI.Models.Teams;
using IncidentTrackerUI.Models.Users;

namespace IncidentTrackerUI.Models.WorkOrders;

/// <summary>
/// A work order. The backend has no list endpoint, so these are read from the
/// <c>workOrders</c> array on GET /api/Incidents.
/// </summary>
public class WorkOrderDto
{
    public Guid Id { get; set; }

    public Guid IncidentId { get; set; }
    public IncidentDto? Incident { get; set; }

    public Guid? AssignedTeamId { get; set; }
    public TeamDto? AssignedTeam { get; set; }

    public Guid? AssignedUserId { get; set; }
    public UserDto? AssignedUser { get; set; }

    public WorkOrderStatus Status { get; set; }
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? StartedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}
