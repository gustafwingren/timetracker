using ErrorOr;
using MediatR;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Contracts;

namespace Timetracker.Application.Users.Queries.GetLoggedInUser;

public class
    GetLoggedInUserQueryHandler : IRequestHandler<GetLoggedInUserQuery, ErrorOr<UserResponse>>
{
    private readonly IUserClient _userClient;

    public GetLoggedInUserQueryHandler(IUserClient userClient)
    {
        _userClient = userClient;
    }

    public async Task<ErrorOr<UserResponse>> Handle(
        GetLoggedInUserQuery request,
        CancellationToken cancellationToken)
    {
        var user = await _userClient.GetUserInfo();

        return user;
    }
}