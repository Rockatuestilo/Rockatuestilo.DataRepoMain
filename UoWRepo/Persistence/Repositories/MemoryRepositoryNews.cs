using System;
using System.Collections.Generic;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories;

[Obsolete]
public class MemoryRepositoryNews : MemoryRepository<NewsEtty>, IRepositoryNews
{
    private readonly IRepositoryNews repositorynews;
    //private readonly IRepository repository;

    public MemoryRepositoryNews(Linq2DbContext context, RepositoryNews repositorynews) : base(context, repositorynews)
    {
        //this.MemoryContext = MemoryContext;
        this.repositorynews = repositorynews;
    }
    
    public MemoryRepositoryNews(string connectionString, RepositoryNews repositorynews) : base(connectionString, repositorynews)
    {
        this.repositorynews = repositorynews;
    }

    [Obsolete]
    public IEnumerable<NewsEtty> GetPagesOfNews(int pageIndex, int pageSize = 10)
    {
        return repositorynews.GetPagesOfNews(pageIndex, pageSize);
    }

    [Obsolete]
    public void UpdatePublicationTime(int articleID, DateTime datetime)
    {
        var newsEntity = new NewsEtty();
        ResetMemory<NewsEtty>();
        repositorynews.UpdatePublicationTime(articleID, datetime);
    }

    [Obsolete]
    public IEnumerable<NewsEtty> GetArticlesByTags(string tagLowered)
    {
        return repositorynews.GetArticlesByTags(tagLowered);
    }
}