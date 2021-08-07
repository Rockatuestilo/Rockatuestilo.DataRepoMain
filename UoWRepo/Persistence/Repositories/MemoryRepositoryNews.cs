using System;
using System.Collections.Generic;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories
{
    public class MemoryRepositoryNews : MemoryRepository<NewsEtty>, IRepositoryNews
    {

        private readonly IRepositoryNews repositorynews;
        //private readonly IRepository repository;

        public MemoryRepositoryNews(Linq2DbContext context, RepositoryNews repositorynews) : base(context, repositorynews)
        {
            //this.MemoryContext = MemoryContext;
            this.repositorynews = repositorynews;
        }

        public IEnumerable<NewsEtty> GetPagesOfNews(int pageIndex, int pageSize = 10)
        {
            return repositorynews.GetPagesOfNews(pageIndex, pageSize);
        }

        public void UpdatePublicationTime(int articleID, DateTime datetime)
        {
            var newsEntity = new NewsEtty();
            base.ResetMemory<NewsEtty>(newsEntity);
            repositorynews.UpdatePublicationTime(articleID, datetime);
        }

        public IEnumerable<NewsEtty> GetArticlesByTags(string tagLowered)
        {
            return repositorynews.GetArticlesByTags(tagLowered);
        }
    }
}
