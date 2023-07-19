using System;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain;

[Table("ArticlesViewForUI")]
public class ArticlesViewForUI : TEntity, IBaseTEntity
{
    [Column("ArticleId")] public int ArticleId { get; set; }

    [Column("UIString")] public string UiString { get; set; } = null!;

    [Column("CreatedByID")] public int CreatedById { get; set; }

    [Column("UpdatedById")] public int UpdatedById { get; set; }

    [Column("LastUpdateOfArticle")] public DateTime LastUpdateOfArticle { get; set; }

    [Column("CreatedDate")] public DateTime CreatedDate { get; set; }
}