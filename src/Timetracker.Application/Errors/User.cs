using ErrorOr;

namespace Timetracker.Application.Errors;

public static class User
{
    public static Error NotFound = Error.NotFound("User.NotFound", "User not found");
}