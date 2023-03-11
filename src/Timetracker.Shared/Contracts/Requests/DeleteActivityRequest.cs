// <copyright file="DeleteActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Shared.Contracts.Requests;

public record DeleteActivityRequest(Guid CustomerId, Guid ActivityId);