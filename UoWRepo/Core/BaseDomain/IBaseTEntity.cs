using System;

namespace UoWRepo.Core.BaseDomain;

public interface IBaseTEntity
{
    int Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
}


public interface IBaseGuidTEntity
{
    Guid Guid { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime UpdatedDate { get; set; }
}