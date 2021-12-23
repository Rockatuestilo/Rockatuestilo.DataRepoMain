using System;

namespace UoWRepo.Core.BaseDomain;

public class BaseTEntity: ITEntity
{
    public int Id { get; set; }
    public DateTime UpdatedDate { get; set; }
}