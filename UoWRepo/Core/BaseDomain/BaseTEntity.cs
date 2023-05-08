using System;

namespace UoWRepo.Core.BaseDomain;

public abstract class BaseTEntity: IBaseTEntity
{
    public virtual int Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
}