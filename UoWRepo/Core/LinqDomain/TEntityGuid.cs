using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain;

public class TEntityGuid : ITEntityGuid
{
    [PrimaryKey]
    [Identity]
    [Column(Name = "Guid")]
    [NotNull]
    public Guid Guid { get; set; }

    public DateTime UpdatedDate { get; set; }
}