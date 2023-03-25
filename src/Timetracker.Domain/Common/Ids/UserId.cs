// <copyright file="UserId.cs" company="gustafwingren">
// Copyright (c) gustafwingren. All rights reserved.
// </copyright>

using StronglyTypedIds;

namespace Timetracker.Domain.Common.Ids;

[StronglyTypedId(StronglyTypedIdBackingType.Guid, StronglyTypedIdConverter.SystemTextJson)]
public partial struct UserId
{
}