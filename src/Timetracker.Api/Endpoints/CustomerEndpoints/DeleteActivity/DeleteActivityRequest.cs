// <copyright file="DeleteActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteActivity;

public record DeleteActivityRequest(Guid CustomerId, Guid ActivityId);