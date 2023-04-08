// <copyright file="GetActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetActivity;

public record GetActivityRequest(Guid CustomerId, Guid ActivityId);