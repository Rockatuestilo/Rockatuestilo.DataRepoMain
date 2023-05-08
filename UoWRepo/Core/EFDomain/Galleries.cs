using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UoWRepo.Core.EFDomain
{
    [Table("galleries")]
    public class Galleries : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("galleryID")]
        public new int Id { get; set; }

        [Column("galleryOwner")]
        public int GalleryOwner { get; set; }

        [Column("galleryName")]
        public string GalleryName { get; set; }

        [Column("galleryPath")]
        public string GalleryPath { get; set; }

        [Column("CreatedByID")]
        public int CreatedById { get; set; }

        [Column("UpdatedByID")]
        public int UpdatedById { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("updatedDate")]
        public new DateTime UpdatedDate { get; set; }

        [Column("categorylevel")]
        public int CategoryLevel { get; set; }

        [Column("publishtype")]
        public int PublishType { get; set; }
    }
}
