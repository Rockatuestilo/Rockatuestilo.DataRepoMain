using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("SharingSocialNetwork")]
public class SharingSocialNetworkLinqDB : TEntity, ITEntity
{
    [Column("Nameofsocialnetwork")]
    public string Nameofsocialnetwork { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public new int Id { get; set; }

    [Column("Createddate")]
    public DateTime CreatedDate { get; set; }

    [Column("Updateddate")]
    public new DateTime UpdatedDate { get; set; }
}