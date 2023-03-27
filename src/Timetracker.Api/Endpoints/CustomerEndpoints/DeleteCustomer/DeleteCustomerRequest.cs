// <copyright file="DeleteCustomerRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.DeleteCustomer;

public record DeleteCustomerRequest(CustomerId Id);