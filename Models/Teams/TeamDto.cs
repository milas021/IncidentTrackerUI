using IncidentTrackerUI.Models.Users;

namespace IncidentTrackerUI.Models.Teams;

/// <summary>Shape returned by GET /api/Team and GET /api/Team/{id}.</summary>
public class TeamDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<UserDto> Users { get; set; } = new();
}
