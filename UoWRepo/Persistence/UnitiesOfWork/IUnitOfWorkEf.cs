using System;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork;

public interface IUnitOfWorkEf
{
    IMemoryRepository<ArticleDataModel> ArticleDataModel { get; }
    IMemoryRepository<ArticlesViewForUi> ArticlesViewForUI { get; }
    IMemoryRepository<Categories> Categories { get; }
    IMemoryRepository<HashTags> HashTags { get; }
    
    //IMemoryRepository<Associations> Associations { get; }
    //IMemoryRepository<TypeAssociation> TypeAssociations { get; }
    
    IRepositoryGuid<Associations> Associations { get; }
    
    IRepositoryGuid<TypeAssociation> TypeAssociations { get; }
    
    
    IMemoryRepository<HashTagsNews> HashTagsNews { get; }
    IMemoryRepository<NewsPublicationType> PublicationType { get; }
    IMemoryRepository<Galleries> Galleries { get; }
    IMemoryRepository<Users> Users { get; }

    [Obsolete("Use ArticleDataModel instead")]
    IMemoryRepository<NewsEtty> News { get; }

    IMemoryRepository<RoleModels> Roles { get; }

    IMemoryRepository<UsersToRoles> UsersToRoles { get; }


    //IRepositoryCategories Categories { get; }
    //IRepositoryHashTags HashTags { get; }
    //IRepositoryHashTagsNews HashTagsNews { get; }
    //IRepositoryNewsPublicationType PublicationType { get; }

    int Complete();
}