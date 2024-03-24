using System;

namespace UoWRepo.Core.BaseDomain;

public interface IArticlesViewForUi: IBaseTEntity
{
    public int ArticleId { get; set; }

    public string UiString { get; set; }

    public int CreatedById { get; set; }

    public int UpdatedById { get; set; }

    public DateTime LastUpdateOfArticle { get; set; }

    public DateTime CreatedDate { get; set; }
}