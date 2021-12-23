using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    public interface IUnitOfWorkEf
    {
        IMemoryRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        IMemoryRepository<Categories> Categories { get; }
        IMemoryRepository<HashTags> HashTags { get; }
        IMemoryRepository<HashTagsNews> HashTagsNews { get; }
        IMemoryRepository<NewsPublicationType> PublicationType { get; }
        IMemoryRepository<Galleries> Galleries { get; }
        IMemoryRepository<Users> Users { get; }
        
        IMemoryRepository<NewsEtty> News { get; }


        //IRepositoryCategories Categories { get; }
        //IRepositoryHashTags HashTags { get; }
        //IRepositoryHashTagsNews HashTagsNews { get; }
        //IRepositoryNewsPublicationType PublicationType { get; }

        IRepositorySharedObject SharedObject { get; }
        IRepositorySharingSocialNetwork SharingSocialNetwork { get; }

        int Complete();
    }
}