using ErrorOr;
using Microsoft.Graph;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;
using User = Timetracker.Application.Errors.User;

namespace Timetracker.Infrastructure.GraphClient;

public class UserClient : IUserClient
{
    private readonly GraphServiceClient _graphServiceClient;

    public UserClient(GraphServiceClient graphServiceClient)
    {
        _graphServiceClient = graphServiceClient;
    }

    public async Task<ErrorOr<UserResponse>> GetUserInfo()
    {
        var user = await _graphServiceClient.Me.Request().GetAsync();

        if (user == null)
        {
            return User.NotFound;
        }

        var userResponse = new UserResponse(
            Guid.Parse(user.Id),
            user.UserPrincipalName,
            user.DisplayName);

        return userResponse;
    }
}