using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    public class RepositoryHashTags: Repository<HashTags>, IRepositoryHashTags
    {
        [Obsolete]
        public RepositoryHashTags(Linq2DbContext context) : base(context)
        {

        }      
    }
}
