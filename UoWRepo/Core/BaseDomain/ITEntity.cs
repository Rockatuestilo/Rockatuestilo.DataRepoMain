using System;

namespace UoWRepo.Core.BaseDomain;

public interface ITEntity
{
    int Id { get; set; }
    DateTime UpdatedDate { get; set; }
}