using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UoWRepo.Core.EFDomain
{
    [Table("ArticlesViewForUI")]
    public class ArticlesViewForUI: TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id { get; set; }

        [Column("ArticleId")]
        public int ArticleId { get; set; }

        [Column("UIString")]
        public string UIString { get; set; }

        [Column("CreatedByID")]
        public int CreatedbyId { get; set; }

        [Column("UpdatedById")]
        public int UpdatedById { get; set; }

        [Column("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [Column("UpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [Column("LastUpdateOfArticle")]
        public DateTime LastUpdateOfArticle { get; set; }
    }
}
