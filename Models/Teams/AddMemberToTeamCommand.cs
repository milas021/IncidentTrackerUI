namespace IncidentTrackerUI.Models.Teams;

/// <summary>Body for POST /api/Team/{id} — assigns the given users as team members.</summary>
public class AddMemberToTeamCommand
{
    public List<Guid> MemberIds { get; set; } = new();
}
