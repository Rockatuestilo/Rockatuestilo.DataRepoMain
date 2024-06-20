using System;

namespace UoWRepo.Core.LinqDomain;

public interface ITEntityGuid
{
    public Guid Guid { get; set; }
    DateTime UpdatedDate { get; set; }
}