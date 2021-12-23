using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    
    public class RepositorySharedObject: Repository<SharedObjectLinqDB>, IRepositorySharedObject
    {
        public RepositorySharedObject(Linq2DbContext context) : base(context)
        {

        }

     
    }
}
