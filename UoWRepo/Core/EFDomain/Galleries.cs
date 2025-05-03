using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("galleries")]
public class Galleries : TEntity, ITEntity
{
    [Column("galleryOwner")] public int GalleryOwner { get; set; }

    [Column("galleryName")] public string? GalleryName { get; set; }

    [Column("galleryPath")] public string GalleryPath { get; set; } = null!;

    [Column("CreatedByID")] public int? CreatedById { get; set; }

    [Column("UpdatedByID")] public int? UpdatedById { get; set; }

    [Column("categorylevel")] public int? CategoryLevel { get; set; }

    [Column("publishtype")] public int? PublishType { get; set; }
       
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("galleryID")]
    public new int Id { get; set; }
}