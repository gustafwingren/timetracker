// <copyright file="CustomerResponse.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using AutoMapper;
using Timetracker.Application.Common.Interfaces;
using Timetracker.Application.Common.Mappings;
using Timetracker.Domain.CustomerAggregate.ValueObjects;

namespace Timetracker.Application.Contracts;

public record CustomerResponse
(
    CustomerId Id,
    string Name,
    string Number,
    IEnumerable<ActivityResponse> Activities) : BaseResponse,
    IMapFrom<Domain.CustomerAggregate.Customer>
{
    public override Guid Guid => Id.Value;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Domain.CustomerAggregate.Customer, CustomerResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.CustomerNr))
            .ForMember(dest => dest.Activities, opt => opt.MapFrom(src => src.Activities));
    }
}