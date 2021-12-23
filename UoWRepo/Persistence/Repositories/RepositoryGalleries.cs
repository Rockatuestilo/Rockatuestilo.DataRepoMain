using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    
    public class RepositoryGalleries: Repository<Galleries>, IRepositoryGalleries
    {
        
        public RepositoryGalleries(Linq2DbContext context) : base(context)
        {

        }
    }
}
