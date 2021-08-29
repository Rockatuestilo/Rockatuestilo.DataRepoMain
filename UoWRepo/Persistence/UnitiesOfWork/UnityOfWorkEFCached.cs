using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    public class UnityOfWorkEFCached: IUnitOfWorkEf
    {
        public IRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        public IRepository<Categories> Categories { get; }
        public IRepository<HashTags> HashTags { get; }
        public IRepository<HashTagsNews> HashTagsNews { get; }
        public IRepository<NewsPublicationType> PublicationType { get; }
        public IRepository<Galleries> Galleries { get; }
        public IRepository<Users> Users { get; }
        public IRepository<NewsEtty> News { get; }
        public IRepositorySharedObject SharedObject { get; }
        public IRepositorySharingSocialNetwork SharingSocialNetwork { get; }
        public int Complete()
        {
            throw new System.NotImplementedException();
        }
    }
}