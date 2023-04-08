// <copyright file="UpdateActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateActivity;

public record UpdateActivityRequest(Guid CustomerId, Guid ActivityId, string Name);