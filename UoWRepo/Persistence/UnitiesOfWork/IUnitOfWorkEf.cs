using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    public interface IUnitOfWorkEf
    {
        IRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        IRepository<Categories> Categories { get; }
        IRepository<HashTags> HashTags { get; }
        IRepository<HashTagsNews> HashTagsNews { get; }
        IRepository<NewsPublicationType> PublicationType { get; }
        IRepository<Galleries> Galleries { get; }
        IRepository<Users> Users { get; }
        
        IRepository<NewsEtty> News { get; }


        //IRepositoryCategories Categories { get; }
        //IRepositoryHashTags HashTags { get; }
        //IRepositoryHashTagsNews HashTagsNews { get; }
        //IRepositoryNewsPublicationType PublicationType { get; }

        IRepositorySharedObject SharedObject { get; }
        IRepositorySharingSocialNetwork SharingSocialNetwork { get; }

        int Complete();
    }
}