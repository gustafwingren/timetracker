// <copyright file="CustomerDto.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

namespace Timetracker.Shared.Contracts.Responses;

public record CustomerDto(Guid Id, string Name, string Number, List<ActivityDto> Activities);