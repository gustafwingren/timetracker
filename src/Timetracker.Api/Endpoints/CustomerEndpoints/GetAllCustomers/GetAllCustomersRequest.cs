namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetAllCustomers;

public record GetAllCustomersRequest(int Page, int PageSize, string SearchString);