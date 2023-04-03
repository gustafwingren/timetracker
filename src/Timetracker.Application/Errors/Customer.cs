// <copyright file="Customer.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;

namespace Timetracker.Application.Errors;

public static class Customer
{
    public static readonly Error NotFound = Error.NotFound(
        "Customer.NotFound",
        "Customer not found");
}