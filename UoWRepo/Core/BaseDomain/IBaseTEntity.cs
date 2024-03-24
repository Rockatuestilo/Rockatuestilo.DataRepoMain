using System;

namespace UoWRepo.Core.BaseDomain;

public interface IBaseTEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
}