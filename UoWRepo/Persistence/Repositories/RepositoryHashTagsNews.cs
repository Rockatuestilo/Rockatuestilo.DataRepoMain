using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    public class RepositoryHashTagsNews: Repository<HashTagsNews>, IRepositoryHashTagsNews
    {
        [Obsolete]
        public RepositoryHashTagsNews(Linq2DbContext context) : base(context)
        {

        } 
    }
}
