using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Table(Name = "ArticlesViewForUI")]
    public class ArticlesViewForUI: TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "ArticleId"), NotNull]
        public int ArticleId { get; set; }

        [Column(Name = "UIString"), NotNull]
        public string UIString { get; set; }

        [Column(Name = "CreatedByID"), NotNull]
        public int CreatedbyId { get; set; }

        [Column(Name = "UpdatedById"), NotNull]
        public int UpdatedById { get; set; }

        [Column(Name = "CreatedDate"), NotNull]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "UpdatedDate"), NotNull]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "LastUpdateOfArticle"), NotNull]
        public DateTime LastUpdateOfArticle { get; set; }
    }
}
