using System;

namespace UoWRepo.Core.Domain;

public interface ITEntityGuid
{
    Guid Guid { get; set; }
    DateTime UpdatedDate { get; set; }
}