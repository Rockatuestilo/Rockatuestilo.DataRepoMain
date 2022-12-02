using System;

namespace UoWRepo.Core.BaseDomain;

public interface IBaseTEntity
{
    int Id { get; set; }
    DateTime UpdatedDate { get; set; }
}