namespace IncidentTrackerUI.Models.Users;

/// <summary>Shape returned by GET /api/Users and GET /api/Users/{id}.</summary>
public class UserDto
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Mobile { get; set; }
}
