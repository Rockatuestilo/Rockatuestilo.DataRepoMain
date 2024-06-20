using System;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;
using ITEntity = UoWRepo.Core.EFDomain.ITEntity;

namespace UoWRepo.Core.LinqDomain;

[Table(Name = "ArticlesViewForUI")]
public class ArticlesViewForUi : Linq2DbEntity, IArticlesViewForUi, ITEntity
{
    [Range(0, int.MaxValue, ErrorMessage = "The value for ArticleId must be greater than -1.")]
    [Column(Name = "ArticleId")] 
    [NotNull]
    public int ArticleId { get; set; }

    [Column(Name = "UIString")] [NotNull] public string UiString { get; set; } = null!;

    [Column(Name = "CreatedByID")]
    [NotNull]
    public int CreatedById { get; set; }

    [Column(Name = "UpdatedById")]
    [NotNull]
    public int UpdatedById { get; set; }

    [Column(Name = "LastUpdateOfArticle")]
    [NotNull]
    public DateTime LastUpdateOfArticle { get; set; }

    [Column(Name = "CreatedDate")]
    [NotNull]
    public DateTime CreatedDate { get; set; }
}