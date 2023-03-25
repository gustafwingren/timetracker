// <copyright file="GetCustomersQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;
using Timetracker.Domain.Common.Ids;
using Timetracker.Shared.Contracts.Responses;

namespace Timetracker.Application.Customer.Queries.GetCustomers;

public record GetCustomersQuery(UserId UserId) : IRequest<List<CustomerDto>>;