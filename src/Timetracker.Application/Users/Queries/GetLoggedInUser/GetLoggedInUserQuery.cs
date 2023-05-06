using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;

namespace Timetracker.Application.Users.Queries.GetLoggedInUser;

public record GetLoggedInUserQuery : IRequest<ErrorOr<UserResponse>>;