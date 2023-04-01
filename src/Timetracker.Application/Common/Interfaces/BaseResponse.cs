// <copyright file="BaseResponse.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Application.Common.Interfaces;

public abstract record BaseResponse
{
    public abstract Guid Guid { get; }
}