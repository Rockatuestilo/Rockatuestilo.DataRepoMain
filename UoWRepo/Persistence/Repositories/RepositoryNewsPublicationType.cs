using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    
    public class RepositoryNewsPublicationType : Repository<NewsPublicationType>, IRepositoryNewsPublicationType
    {
        public RepositoryNewsPublicationType(Linq2DbContext context) : base(context)
        {

        }
    }
}
