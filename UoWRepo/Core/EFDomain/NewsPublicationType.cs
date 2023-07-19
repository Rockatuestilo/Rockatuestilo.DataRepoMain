using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("NewsPublicationType")]
public class NewsPublicationType : TEntity, ITEntity
{
    [Column("TypeOfPublication")] public string TypeOfPublication { get; set; }

    [Column("LevelUser")] public int LevelUser { get; set; }

    [Column("CreatedByID")] public int CreatedById { get; set; }

    [Column("UpdatedByID")] public int UpdatedById { get; set; }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("NewsPublicationTypeID")]
    public new int Id { get; set; }

    [Column("CreatedDate")] public DateTime CreatedDate { get; set; }

    [Column("updatedDate")] public new DateTime UpdatedDate { get; set; }
}