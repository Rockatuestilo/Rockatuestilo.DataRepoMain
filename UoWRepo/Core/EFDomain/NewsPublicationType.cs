using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [Table("NewsPublicationType")]
    public class NewsPublicationType : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("NewsPublicationTypeID")]
        public int Id { get; set; }

        [Column("TypeOfPublication")]
        public string Typeofpublication { get; set; }

        [Column("LevelUser")]
        public int Leveluser { get; set; }

        [Column("CreatedByID")]
        public int Createdbyid { get; set; }

        [Column("UpdatedByID")]
        public int Updatedbyid { get; set; }

        [Column("CreatedDate")]
        public DateTime Createddate { get; set; }

        [Column("updatedDate")]
        public DateTime UpdatedDate { get; set; }
    }
}
