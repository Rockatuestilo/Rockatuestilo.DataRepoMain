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
        public int Id { get; set; }

        [Column("galleryOwner")]
        public int Galleryowner { get; set; }

        [Column("galleryName")]
        public string Galleryname { get; set; }

        [Column("galleryPath")]
        public string Gallerypath { get; set; }

        [Column("CreatedByID")]
        public int Createdbyid { get; set; }

        [Column("UpdatedByID")]
        public int Updatedbyid { get; set; }

        [Column("CreatedDate")]
        public DateTime Createddate { get; set; }

        [Column("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [Column("categorylevel")]
        public int Categorylevel { get; set; }

        [Column("publishtype")]
        public int Publishtype { get; set; }
    }
}
