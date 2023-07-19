using System;

namespace UoWRepo.Core.EFDomain;

public class TEntityGuid : Domain.ITEntityGuid
{
    public Guid Guid { get; set; }

    public DateTime UpdatedDate { get; set; }
}