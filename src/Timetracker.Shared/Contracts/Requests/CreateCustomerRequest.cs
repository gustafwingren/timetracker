// <copyright file="CreateCustomerRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Shared.Contracts.Requests;

public record CreateCustomerRequest(string Name, string Number);