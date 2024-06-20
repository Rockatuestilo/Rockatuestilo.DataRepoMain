using System;
using UoWRepo.Core.LinqDomain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork;


public interface IUnitOfWork : IDisposable
{
    IMemoryRepository<ArticlesViewForUi> ArticlesViewForUI { get; }
    IMemoryRepository<Categories> Categories { get; }
    IMemoryRepository<HashTags> HashTags { get; }
    IMemoryRepository<HashTagsNews> HashTagsNews { get; }
    IMemoryRepository<NewsPublicationType> PublicationType { get; }
    IMemoryRepository<Galleries> Galleries { get; }
    IMemoryRepository<Users> Users { get; }
    IMemoryRepository<NewsEtty> News { get; }

    public IMemoryRepository<RoleModels> Roles { get; }
    public IMemoryRepository<UsersToRoles> UsersToRoles { get; }


    int Complete();
}


public interface IUnitOfWorkMemory : IDisposable
{
    IMemoryRepository<ArticlesViewForUi> ArticlesViewForUI { get; }
    IMemoryRepository<Categories> Categories { get; }
    IMemoryRepository<HashTags> HashTags { get; }
    IMemoryRepository<HashTagsNews> HashTagsNews { get; }
    IMemoryRepository<NewsPublicationType> PublicationType { get; }
    IMemoryRepository<Galleries> Galleries { get; }
    IMemoryRepository<Users> Users { get; }
    IMemoryRepository<NewsEtty> News { get; }

    public IMemoryRepository<RoleModels> Roles { get; }
    public IMemoryRepository<UsersToRoles> UsersToRoles { get; }


    int Complete();
}