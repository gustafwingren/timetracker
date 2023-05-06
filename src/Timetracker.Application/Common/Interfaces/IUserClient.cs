using ErrorOr;
using Timetracker.Application.Contracts;

namespace Timetracker.Application.Common.Interfaces;

public interface IUserClient
{
    Task<ErrorOr<UserResponse>> GetUserInfo();
}