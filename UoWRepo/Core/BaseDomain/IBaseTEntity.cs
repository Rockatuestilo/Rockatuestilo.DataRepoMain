using System;

namespace UoWRepo.Core.BaseDomain;

public interface IBaseTEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}

public interface IBaseGuidTEntity
{
    public Guid Guid { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}