using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain
{
    [Table("Hashtags")]
    public class HashTags : TEntity, IHashTags
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public new int Id { get; set; }

        [Column("HashtagWord")]
        public string HashtagWord { get; set; }

        [Column("Allowed")]
        public byte Allowed { get; set; }

        [Column("CreatedByID")]
        public int CreatedById { get; set; }

        [Column("UpdatedByID")]
        public int UpdatedById { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("updatedDate")]
        public new DateTime UpdatedDate { get; set; }
    }
}


