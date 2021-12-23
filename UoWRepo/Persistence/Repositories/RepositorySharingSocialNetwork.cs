using System;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    
    public class RepositorySharingSocialNetwork: Repository<SharingSocialNetworkLinqDB>, IRepositorySharingSocialNetwork
    {
        public RepositorySharingSocialNetwork(Linq2DbContext context) : base(context)
        {

        }
    }
}
