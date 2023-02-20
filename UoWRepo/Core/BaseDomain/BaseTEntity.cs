using System;

namespace UoWRepo.Core.BaseDomain;

public abstract class BaseTEntity: IBaseTEntity
{
    public int Id { get; set; }
    public DateTime UpdatedDate { get; set; }
}