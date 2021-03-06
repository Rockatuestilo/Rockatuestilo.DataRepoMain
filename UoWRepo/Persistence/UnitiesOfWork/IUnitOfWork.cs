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
        IMemoryRepository<NewsEtty> News { get; }
        IRepositorySharedObject SharedObject { get; }
        IRepositorySharingSocialNetwork SharingSocialNetwork { get; }
        
        

        int Complete();
    }
}
