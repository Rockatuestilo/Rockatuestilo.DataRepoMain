using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [Table("HashtagsNews")]
    public class HashTagsNews : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("NewsID")]
        public int NewsId { get; set; }

        [Column("HashtagID")]
        public int HashtagId { get; set; }

        [Column("CreatedByID")]
        public int CreatedById { get; set; }

        [Column("UpdatedByID")]
        public int UpdatedById { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        public static explicit operator HashTagsNews(int v)
        {
            throw new NotImplementedException();
        }
    }
}



