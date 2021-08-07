using UoWRepo.Core.Configuration;
using UoWRepo.Core.Repositories;
using UoWRepo.Core.Domain;

namespace UoWRepo.Persistence.Repositories
{
    public class RepositoryUsers : Repository<Users>, IRepositoryUsers
    {
        public RepositoryUsers(Linq2DbContext context) : base(context)
        {

        }
    }
}
