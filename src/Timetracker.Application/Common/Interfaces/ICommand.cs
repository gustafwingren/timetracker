// <copyright file="ICommandRequest.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using MediatR;

namespace Timetracker.Application.Common.Interfaces;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}