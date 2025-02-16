﻿using System;
using UoWRepo.Core.LinqDomain;
using UoWRepo.Core.Repositories;

// ReSharper disable UnusedMemberInSuper.Global

namespace UoWRepo.Persistence.UnitiesOfWork;

[Obsolete("Use IUnitOfWorkEF instead")]
public interface IUnitOfWorkLinq : IDisposable
{
    IRepository<ArticleDataModel> ArticleDataModel { get; }
    
    IRepository<ArticlesViewForUi> ArticlesViewForUI { get; }
    IRepository<Categories> Categories { get; }
    IRepository<HashTags> HashTags { get; }
    IRepository<HashTagsNews> HashTagsNews { get; }
    IRepository<NewsPublicationType> PublicationType { get; }
    IRepository<Galleries> Galleries { get; }
    IRepository<Users> Users { get; }
    IRepository<NewsEtty> News { get; }

    public IRepository<RoleModels> Roles { get; }
    public IRepository<UsersToRoles> UsersToRoles { get; }
    
    public IRepository<PendingRegistration> PendingRegistration { get;  }


    int Complete();
}