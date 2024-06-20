using System;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Repositories;

public interface IMemoryRepositoryGuid<TEntityGuid> : IRepositoryGuid<TEntityGuid> where TEntityGuid : IBaseGuidTEntity
{
    DateTime? GetDateTimeOfCachingOfCurrentEntity();
}