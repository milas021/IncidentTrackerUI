using System.ComponentModel.DataAnnotations;

namespace IncidentTrackerUI.Models.Users;

/// <summary>Body for POST /api/Users.</summary>
public class CreateUserCommand
{
    [Required]
    public string? FullName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Mobile { get; set; }
}
