using System;

namespace UoWRepo.Core.EFDomain;

public interface ITEntityGuid
{
    Guid Guid { get; set; }
    DateTime UpdatedDate { get; set; }
}