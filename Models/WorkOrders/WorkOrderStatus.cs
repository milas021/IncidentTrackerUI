namespace IncidentTrackerUI.Models.WorkOrders;

// Backend exposes this only as integers 1-5 in Swagger; names below are the conventional
// work-order lifecycle and may need tweaking if the API's enum names differ.
public enum WorkOrderStatus
{
    Created = 1,
    Assigned = 2,
    InProgress = 3,
    Completed = 4,
    Cancelled = 5,
}
