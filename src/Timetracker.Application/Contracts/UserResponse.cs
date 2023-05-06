using Timetracker.Application.Common.Interfaces;

namespace Timetracker.Application.Contracts;

public record UserResponse(
    Guid Id,
    string UserName,
    string DisplayName) : BaseResponse
{
    public override Guid Guid => Id;
}