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

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public new int Id { get; set; }

    [Column("Createddate")]
    public DateTime CreatedDate { get; set; }

    [Column("Updateddate")]
    public new DateTime UpdatedDate { get; set; }
}