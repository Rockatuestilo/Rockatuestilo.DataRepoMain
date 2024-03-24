using System;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;
using UoWRepo.Migrations;
using UoWRepo.Persistence.RepositoriesEf;
//using UoWRepo.Core.Domain;
//using UoWRepo.Persistence.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork;

public class UnityOfWorkEf : IUnitOfWorkEf
{
    private readonly EFContext _context;

    public UnityOfWorkEf(EFContext context)
    {
        _context = context;

        //Users = new RepositoryEf<Users>(_context);
        Users = InitObjects<Users>();
        News = InitObjects<NewsEtty>();
        HashTags = InitObjects<HashTags>();
        ArticlesViewForUI = InitObjects<ArticlesViewForUi>();
        Categories = InitObjects<Categories>();
        HashTagsNews = InitObjects<HashTagsNews>();

        PublicationType = InitObjects<NewsPublicationType>();
        Galleries = InitObjects<Galleries>();


        Roles = InitObjects<RoleModels>();
        UsersToRoles = InitObjects<UsersToRoles>();
        ArticleDataModel = InitObjects<ArticleDataModel>();
        
    }

    public IMemoryRepository<ArticleDataModel> ArticleDataModel { get; }
    public IMemoryRepository<ArticlesViewForUi> ArticlesViewForUI { get; }
    public IMemoryRepository<Categories> Categories { get; }
    public IMemoryRepository<HashTags> HashTags { get; }
    public IMemoryRepository<HashTagsNews> HashTagsNews { get; }
    public IMemoryRepository<NewsPublicationType> PublicationType { get; }
    public IMemoryRepository<Galleries> Galleries { get; }
    public IMemoryRepository<Users> Users { get; }
    public IMemoryRepository<NewsEtty> News { get; }
    public IMemoryRepository<RoleModels> Roles { get; }
    public IMemoryRepository<UsersToRoles> UsersToRoles { get; }

    //public IRepositorySharedObject SharedObject { get; }
    //public IRepositorySharingSocialNetwork SharingSocialNetwork { get; }
    public int Complete()
    {
        return _context.SaveChanges();
    }

    private MemoryRepositoryEF<T> InitObjects<T>() where T : BaseTEntity
    {
        return new MemoryRepositoryEF<T>(_context, new RepositoryEf<T>(_context));
    }


    private IServiceProvider CreateServices(string connection)
    {
        //var h= System.Reflection.Assembly.GetExecutingAssembly();

        return new ServiceCollection() // Add common FluentMigrator services
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
                // Add SQLite support to FluentMigrator
                .AddMySql5()

                // Set the connection string
                .WithGlobalConnectionString(connection)
                // Define the assembly containing the migrations
                //.ScanIn(typeof(UoWRepo.Migrations.AddNewColumnVersionOfNews).Assembly).For.Migrations()
                .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations()
            )

            // Build the service provider
            .BuildServiceProvider(false);
    }


    private void UpdateDatabase(IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            // Instantiate the runner
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations
            runner.MigrateUp();
            runner.Up(new AddNewColumnVersionOfNews());
        }
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}