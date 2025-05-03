using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("SharedObject")]
public class SharedObjectLinqDB : TEntity, ITEntity
{
    [Column("Sharingsocialnetworkid")]
    public int Sharingsocialnetworkid { get; set; }

    [Column("Note")] public string Note { get; set; }

    [Column("IdOfSharedelement")]
    public int IdOfSharedelement { get; set; }

    [Column("Typeid")] public int Typeid { get; set; }

}