using System.Text.Json;

namespace IncidentTrackerUI.Shared;

/// <summary>
/// Shared JSON options for calls made through the keyed "Api" HttpClient, so requests/responses
/// use the same camelCase property names as the backend (e.g. "installedAt", not "InstalledAt").
/// </summary>
public static class ApiJson
{
    public static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);
}
