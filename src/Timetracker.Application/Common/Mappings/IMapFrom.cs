// <copyright file="IMapFrom.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using AutoMapper;

namespace Timetracker.Application.Common.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile)
    {
        profile.CreateMap(typeof(T), GetType());
    }
}