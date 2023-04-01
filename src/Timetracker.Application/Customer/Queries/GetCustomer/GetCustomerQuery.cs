// <copyright file="GetCustomerQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using LanguageExt.Common;
using MediatR;
using Timetracker.Application.Contracts;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Customer.Queries.GetCustomer;

public record GetCustomerQuery(CustomerId Id) : IRequest<Result<CustomerResponse>>;