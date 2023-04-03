// <copyright file="IQuery.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;

namespace Timetracker.Application.Common.Interfaces;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}