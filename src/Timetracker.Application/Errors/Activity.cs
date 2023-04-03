// <copyright file="Activity.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;

namespace Timetracker.Application.Errors;

public static class Activity
{
    public static Error NotFound = Error.NotFound("Activity.NotFound", "Activity not found");
}