using System;
using System.Collections.Generic;
using UoWRepo.Core.Domain;

namespace UoWRepo.Core.Repositories;

public interface IRepositoryNews : IRepository<NewsEtty>
{
    new void Update(NewsEtty entity);

    IEnumerable<NewsEtty> GetPagesOfNews(int pageIndex, int pageSize = 10);

    void UpdatePublicationTime(int articleID, DateTime datetime);

    IEnumerable<NewsEtty> GetArticlesByTags(string tagLowered);
}