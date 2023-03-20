// <copyright file="GetActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Shared.Contracts.Requests;

public record GetActivityRequest(Guid CustomerId, Guid ActivityId);