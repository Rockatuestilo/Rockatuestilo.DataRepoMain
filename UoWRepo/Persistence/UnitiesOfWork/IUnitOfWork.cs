using System;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    
    public interface IUnitOfWork: IDisposable
    {
        IRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        IRepository<Categories> Categories { get; }
        IRepository<HashTags> HashTags { get; }
        IRepository<HashTagsNews> HashTagsNews { get; }
        IRepository<NewsPublicationType> PublicationType { get; }
        IRepository<Galleries> Galleries { get; }
        IRepository<Users> Users { get; }


        //IRepositoryCategories Categories { get; }
        //IRepositoryHashTags HashTags { get; }
        //IRepositoryHashTagsNews HashTagsNews { get; }
        //IRepositoryNewsPublicationType PublicationType { get; }

        IRepositoryNews News { get; }



        IRepositorySharedObject SharedObject { get; }
        IRepositorySharingSocialNetwork SharingSocialNetwork { get; }

        int Complete();
    }
}
