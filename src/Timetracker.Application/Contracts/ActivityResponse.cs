// <copyright file="ActivityResponse.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using AutoMapper;
using Timetracker.Application.Common.Mappings;
using Timetracker.Domain.CustomerAggregate.Entities;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Contracts;

public record ActivityResponse(ActivityId Id, string Name) : IMapFrom<Activity>
{
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Activity, ActivityResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
    }
}