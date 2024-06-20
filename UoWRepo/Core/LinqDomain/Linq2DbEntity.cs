using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.LinqDomain;

public class Linq2DbEntity : BaseTEntity
{
    [PrimaryKey]
    [Identity]
    [Column(Name = "Id")]
    [NotNull]
    public new int Id { get; set; }

    [Column(Name = "CreatedDate")]
    [NotNull]
    public virtual DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column(Name = "UpdatedDate")]
    [NotNull]
    public override DateTime UpdatedDate { get; set; } = DateTime.Now;
}