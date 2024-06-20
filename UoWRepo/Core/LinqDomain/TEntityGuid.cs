using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.LinqDomain;

public class TEntityGuid : ITEntityGuid
{
    [PrimaryKey]
    [Identity]
    [Column(Name = "Guid")]
    [NotNull]
    public Guid Guid { get; set; }

    public DateTime UpdatedDate { get; set; }
}