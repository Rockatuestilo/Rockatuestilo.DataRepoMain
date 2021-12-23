﻿using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;
using UoWRepo.Migrations;
using UoWRepo.Persistence.Repositories;
using FluentMigrator.Runner;
using System.Collections.Generic;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    //TODO: test this
    public class ArticlesHomeUnityOfWork 
    {
        private readonly Linq2DbContext context;

        public ArticlesHomeUnityOfWork(Linq2DbContext context)
        {
            this.context = context;
        }
        
        

        public IEnumerable<NewsEtty> GetArticlesPerPageByHashtag(string hashtag, int userLevel, int currentPage, int pageSize) 
        {

            /*var types = context.NewsPublicationType.Where(x => x.Leveluser <= userLevel);
            ResultArticles = (from p in ResultArticles
                              join t in types on p.Publicationtype equals t.Id
                              select new { p }).Select(x => x.p);*/

            var arts =
                        (

                        from ht in context.HashTags
                        join ntN in context.HashtagsNews on ht.Id equals ntN.HashtagId
                        join articles in context.tb_news on ntN.NewsId equals articles.Id
                        join publictaionTypes in context.NewsPublicationType on articles.Publicationtype equals publictaionTypes.Id
                        where ht.HashtagWord == hashtag
                        where publictaionTypes.Leveluser <= userLevel
                        
                        select new { articles }).Skip(pageSize * (currentPage)).Take(pageSize).Select(x => x.articles).ToList();

            return arts;




        }
    }

    public class UnityOfWork: IUnitOfWork
    {
        private Linq2DbContext _context;

        public UnityOfWork(Linq2DbContext context)
        {


            _context = context;
            //News = new RepositoryNews(_context);
            //Galleries = new RepositoryGalleries(_context);
            //Users = new RepositoryUsers(_context);
            SharedObject = new RepositorySharedObject(_context);
            SharingSocialNetwork = new RepositorySharingSocialNetwork(_context);

            //ArticlesViewForUI = new Repository<ArticlesViewForUI>(_context);
            //Categories = new RepositoryCategories(_context);
            //Categories = new RepositoryCategories(_context);


            News = new MemoryRepositoryNews(_context, new RepositoryNews(_context));


            PublicationType = new MemoryRepository<NewsPublicationType>(_context, new Repository<NewsPublicationType>(_context));
            HashTags = new MemoryRepository<HashTags>(_context, new Repository<HashTags>(_context));
            HashTagsNews = new MemoryRepository<HashTagsNews>(_context, new Repository<HashTagsNews>(_context));
            Categories = new MemoryRepository<Categories>(_context, new Repository<Categories>(_context));
            ArticlesViewForUI = new MemoryRepository<ArticlesViewForUI>(_context, new Repository<ArticlesViewForUI>(_context));

            Galleries = new MemoryRepository<Galleries>(_context, new Repository<Galleries>(_context));
            Users = new MemoryRepository<Users>(_context, new Repository<Users>(_context));
            
            PendingRegistration = new MemoryRepository<PendingRegistration>(_context, new Repository<PendingRegistration>(_context));

            new MigrationsModule(_context.ConfigurationString).DoSomeMigration();

            

        }

        public IRepository<ArticlesViewForUI> ArticlesViewForUI { get; private set; }
        public IRepository<Categories> Categories { get; private set; }
        public IRepository<HashTags> HashTags { get; private set; }
        public IRepository<HashTagsNews> HashTagsNews { get; private set; }
        public IRepository<NewsPublicationType> PublicationType { get; private set; }
        public IRepository<Galleries> Galleries { get; private set; }
        public IRepository<Users> Users { get; private set; }
        
        public IRepository<PendingRegistration> PendingRegistration { get; private set; }

        //public IRepositoryNewsPublicationType PublicationType { get; private set; }
        //public IRepositoryCategories Categories { get; private set; }
        //public IRepositoryHashTags HashTags { get; private set; }
        //public IRepositoryHashTagsNews HashTagsNews { get; private set; }


        public IRepositoryNews News { get; private set; }
        //public IRepositoryGalleries Galleries { get; private set; }
        //public IRepositoryUsers Users { get; private set; }
        public IRepositorySharedObject SharedObject { get; private set; }
        public IRepositorySharingSocialNetwork SharingSocialNetwork { get; private set; }

       
        



        public int Complete()
        {          
            if (_context.Transaction != null)
            {
                try
                {
                    _context.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    var hhh = ex.Message;
                }


            }
            return 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public class MigrationsModule
    {
        private readonly string _connectionString;

        public MigrationsModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DoSomeMigration() 
        {
            //var hh = new MigrationBase();

            var serviceProvider = CreateServices(_connectionString);

            //serviceProvider.
            

       
            try
            {
                UpdateDatabase(serviceProvider);
            }
            catch (Exception ex)
            {
                var hhshshs = ex.Message;
                var hhshshss = ex.InnerException;
            }
            


        }

        
        private IServiceProvider CreateServices(string connection)
        {

            //var h= System.Reflection.Assembly.GetExecutingAssembly();

            return new ServiceCollection()// Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddMySql5()
                    
                    // Set the connection string
                    .WithGlobalConnectionString(connection)
                    // Define the assembly containing the migrations
                    //.ScanIn(typeof(UoWRepo.Migrations.AddUIViewArticles).Assembly).For.Migrations()
                    .ScanIn(System.Reflection.Assembly.GetExecutingAssembly()).For.Migrations()
                )
               
                // Build the service provider
                .BuildServiceProvider(false);
        }

        private void UpdateDatabase(IServiceProvider serviceProvider)
        {
            // Instantiate the runner
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();

            // Execute the migrations



            runner.MigrateUp();
            runner.Up(new DeleteUnneededStuff());
        }

        
    }
}
