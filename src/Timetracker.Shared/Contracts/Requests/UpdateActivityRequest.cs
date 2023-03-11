// <copyright file="UpdateActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Shared.Contracts.Requests;

public record UpdateActivityRequest(Guid CustomerId, Guid ActivityId, string Name);