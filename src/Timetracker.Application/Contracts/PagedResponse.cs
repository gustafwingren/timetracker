namespace Timetracker.Application.Contracts;

public record PagedResponse<T>(List<T> Items, int TotalCount)
    where T : CustomerResponse;