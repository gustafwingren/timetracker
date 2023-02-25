// <copyright file="GetCustomersQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Shared.Dtos;

namespace Timetracker.Application.Customer.Queries.GetCustomers;

public record GetCustomersQuery : IRequest<List<CustomerDto>>;