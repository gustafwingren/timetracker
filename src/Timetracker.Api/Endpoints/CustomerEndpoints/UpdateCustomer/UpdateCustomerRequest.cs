// <copyright file="UpdateCustomerRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Api.Endpoints.CustomerEndpoints.UpdateCustomer;

public record UpdateCustomerRequest(Guid Id, string Name, string Number);