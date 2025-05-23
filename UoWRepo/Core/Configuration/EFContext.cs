﻿using System;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.EFDomain;
using ArticlesViewForUi = UoWRepo.Core.EFDomain.ArticlesViewForUi;
using Categories = UoWRepo.Core.EFDomain.Categories;
using Galleries = UoWRepo.Core.EFDomain.Galleries;
using HashTags = UoWRepo.Core.EFDomain.HashTags;
using HashTagsNews = UoWRepo.Core.EFDomain.HashTagsNews;
using NewsEtty = UoWRepo.Core.EFDomain.NewsEtty;
using NewsPublicationType = UoWRepo.Core.EFDomain.NewsPublicationType;
using PendingRegistration = UoWRepo.Core.EFDomain.PendingRegistration;
using RoleModels = UoWRepo.Core.EFDomain.RoleModels;
using SharedObjectLinqDB = UoWRepo.Core.EFDomain.SharedObjectLinqDB;
using SharingSocialNetworkLinqDB = UoWRepo.Core.EFDomain.SharingSocialNetworkLinqDB;
using Users = UoWRepo.Core.EFDomain.Users;
using UsersToRoles = UoWRepo.Core.EFDomain.UsersToRoles;

namespace UoWRepo.Core.Configuration;

public class EFContext : DbContext, ICommonContext
{
    private readonly string connectionString;

    public EFContext(DbContextOptions<EFContext> options)
        : base(options)
    {
    }

    public EFContext(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public DbSet<ArticlesViewForUi> ArticlesViewForUI { get; set; }
    
    public DbSet<ArticleDataModel> ArticleDataModel { get; set; }

    public DbSet<NewsEtty> NewsEtty { get; set; }

    public DbSet<Galleries> Galleries { get; set; }

    public DbSet<Users> Users { get; set; }

    public DbSet<Categories> Categories { get; set; }

    public DbSet<HashTags> HashTags { get; set; }

    public DbSet<HashTagsNews> HashtagsNews { get; set; }

    public DbSet<SharingSocialNetworkLinqDB> SharingSocialNetwork { get; set; }

    public DbSet<SharedObjectLinqDB> SharedObject { get; set; }

    public DbSet<NewsPublicationType> NewsPublicationType { get; set; }

    public DbSet<PendingRegistration> PendingRegistration { get; set; }

    public DbSet<RoleModels> Roles { get; set; }
    public DbSet<UsersToRoles> UsersToRoles { get; set; }
    
    public DbSet<TypeAssociation> TypeAssociation { get; set; }
    public DbSet<Associations> Associations { get; set; }
    
    public DbSet<SubjectsDatamodel> Subjects { get; set; }
    public DbSet<Media> Media { get; set; }
    public DbSet<SubjectMedia> SubjectMedia { get; set; }
    public DbSet<SubjectRelationships> SubjectRelationships { get; set; }
    
    // 1) Entidad Authors
    public DbSet<Authors> Authors { get; set; }

    // 2) Entidad ArticleMedia (la tabla N:M Artículo–Media)
    public DbSet<ArticleMedia> ArticleMedia { get; set; }

    // 3) Entidad SubjectTypes (lookup de tipos de subject)
    public DbSet<SubjectTypes> SubjectTypes { get; set; }
    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        try
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            optionsBuilder.UseMySQL(connectionString);
        }
        catch (TypeLoadException exception)
        {
            var gh = exception.Message;
        }
    }
}