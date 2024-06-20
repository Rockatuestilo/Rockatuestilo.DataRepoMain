using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.LinqDomain;

[Table(Name = "SharedObject")]
public class SharedObjectLinqDB : Linq2DbEntity, ITEntity
{
    [Column(Name = "Sharingsocialnetworkid")]
    [NotNull]
    public int Sharingsocialnetworkid { get; set; }

    [Column(Name = "Note")] [NotNull] public string Note { get; set; }

    [Column(Name = "IdOfSharedelement")]
    [NotNull]
    public int IdOfSharedelement { get; set; }

    [Column(Name = "Typeid")] [NotNull] public int Typeid { get; set; }

    [Column(Name = "Createddate")]
    [NotNull]
    public DateTime CreatedDate { get; set; }

    [Column(Name = "Updateddate")]
    [NotNull]
    public new DateTime UpdatedDate { get; set; }
}