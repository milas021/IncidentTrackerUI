using System.ComponentModel.DataAnnotations;

namespace IncidentTrackerUI.Models.WorkOrders;

/// <summary>Body for POST /api/WorkOrders.</summary>
public class AddWorkOrderCommand
{
    [Required]
    public Guid IncidentId { get; set; }

    public Guid? AssignedTeamId { get; set; }

    public Guid? AssignedUserId { get; set; }

    public string? Description { get; set; }
}
