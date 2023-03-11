// <copyright file="GetCustomerQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Queries.GetCustomer;

public record GetCustomerQuery(Guid Id) : IRequest<CustomerDto>;