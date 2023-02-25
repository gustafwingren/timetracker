// <copyright file="GetCustomerQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Dtos;

namespace Timetracker.Application.Customer.Queries.GetCustomer;

public record GetCustomerQuery : IRequest<CustomerDto>
{
    public Guid Id { get; init; }
}