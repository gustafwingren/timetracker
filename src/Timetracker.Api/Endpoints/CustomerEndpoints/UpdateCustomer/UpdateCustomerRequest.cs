// <copyright file="UpdateCustomerRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

public record UpdateCustomerRequest(CustomerId Id, string Name, string Number);