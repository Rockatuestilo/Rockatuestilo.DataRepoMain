using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain
{

    [Table(Name = "ArticlesViewForUI")]
    public class ArticlesViewForUI: Linq2DbEntity, IBaseTEntity
    {
        [Column(Name = "ArticleId"), NotNull]
        public int ArticleId { get; set; }

        [Column(Name = "UIString"), NotNull]
        public string UiString { get; set; } = null!;

        [Column(Name = "CreatedByID"), NotNull]
        public int CreatedById { get; set; } 

        [Column(Name = "UpdatedById"), NotNull]
        public int UpdatedById { get; set; }

        [Column(Name = "CreatedDate"), NotNull]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "LastUpdateOfArticle"), NotNull]
        public DateTime LastUpdateOfArticle { get; set; }
    }
}
