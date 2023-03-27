// <copyright file="GetCustomerRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.GetCustomer;

public record GetCustomerRequest(CustomerId Id);