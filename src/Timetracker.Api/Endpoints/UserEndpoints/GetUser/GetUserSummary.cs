using System.Net.Mime;
using FastEndpoints;
using Timetracker.Application.Contracts;

namespace Timetracker.Api.Endpoints.UserEndpoints.GetUser;

public sealed class GetUserSummary : Summary<GetUserEndpoint>
{
    public GetUserSummary()
    {
        Summary = "Get user";
        Description = "Use this endpoint to get userinfo for logged in user";
        Response(
            200,
            "User info",
            MediaTypeNames.Application.Json,
            new UserResponse(Guid.NewGuid(), "username", "Test Testsson"));
        Response(400, "Bad request");
        Response(401, "Unauthorized");
    }
}