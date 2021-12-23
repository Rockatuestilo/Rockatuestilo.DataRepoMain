using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    
    public class RepositoryCategories: Repository<Categories>, IRepositoryCategories
    {
        public RepositoryCategories(Linq2DbContext context) : base(context)
        {

        }
    }
}
