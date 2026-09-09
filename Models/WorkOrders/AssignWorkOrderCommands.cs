namespace IncidentTrackerUI.Models.WorkOrders;

/// <summary>Body for PUT /api/WorkOrders/{id}/assign-team.</summary>
public class AssignWorkOrderToTeamCommand
{
    public Guid TeamId { get; set; }
}

/// <summary>Body for PUT /api/WorkOrders/{id}/assign-user.</summary>
public class AssignWorkOrderToUserCommand
{
    public Guid UserId { get; set; }
}
