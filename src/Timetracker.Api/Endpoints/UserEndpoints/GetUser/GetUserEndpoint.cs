using FastEndpoints;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Application.Users.Queries.GetLoggedInUser;

namespace Timetracker.Api.Endpoints.UserEndpoints.GetUser;

public sealed class GetUserEndpoint : EndpointWithoutRequest<UserResponse>
{
    private readonly ISender _sender;

    public GetUserEndpoint(ISender sender)
    {
        _sender = sender;
    }

    public override void Configure()
    {
        Get("users/me");
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var query = new GetLoggedInUserQuery();
        var user = await _sender.Send(query, ct);

        await SendInterceptedAsync(user, cancellation: ct);
    }
}