// <copyright file="CreateActivityRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Api.Endpoints.CustomerEndpoints.CreateActivity;

public record CreateActivityRequest(Guid CustomerId, string Name);