using System;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    
    public interface IUnitOfWork: IDisposable
    {
        IMemoryRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        IMemoryRepository<Categories> Categories { get; }
        IMemoryRepository<HashTags> HashTags { get; }
        IMemoryRepository<HashTagsNews> HashTagsNews { get; }
        IMemoryRepository<NewsPublicationType> PublicationType { get; }
        IMemoryRepository<Galleries> Galleries { get; }
        IMemoryRepository<Users> Users { get; }


        //IRepositoryCategories Categories { get; }
        //IRepositoryHashTags HashTags { get; }
        //IRepositoryHashTagsNews HashTagsNews { get; }
        //IRepositoryNewsPublicationType PublicationType { get; }

        IRepositoryNews News { get; }
        
        IMemoryRepository<NewsEtty> NewsV2 { get; }

        IRepositorySharedObject SharedObject { get; }
        IRepositorySharingSocialNetwork SharingSocialNetwork { get; }

        int Complete();
    }
}
