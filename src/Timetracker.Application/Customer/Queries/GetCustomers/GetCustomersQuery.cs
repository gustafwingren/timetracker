// <copyright file="GetCustomersQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using ErrorOr;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.Common.Ids;

namespace Timetracker.Application.Customer.Queries.GetCustomers;

public record GetCustomersQuery
    (UserId UserId, string SearchString, int Page, int PageSize) : IRequest<
        ErrorOr<PagedResponse<CustomerResponse>>>;