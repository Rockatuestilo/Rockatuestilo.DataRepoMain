using System;
using Microsoft.Extensions.DependencyInjection;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;
using UoWRepo.Migrations;
using UoWRepo.Persistence.Repositories;
using FluentMigrator.Runner;
using LinqToDB;
using MySql.Data.MySqlClient;
using UoWRepo.Migrations.Manual;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    //TODO: test this

    public class UnityOfWork: IUnitOfWork
    {
        private Linq2DbContext _context;

        public UnityOfWork(Linq2DbContext context)
        {
            _context = context;     
            //new MigrationsModule(_context.ConfigurationString).DoSomeMigration();
            new RunFirstMigration(context);
            //RunStupidMigration();
            News = new MemoryRepository<NewsEtty>(_context, new Repository<NewsEtty>(_context)) as MemoryRepository<NewsEtty>;

            PublicationType = new MemoryRepository<NewsPublicationType>(_context, new Repository<NewsPublicationType>(_context)) ;
            HashTags = new MemoryRepository<HashTags>(_context, new Repository<HashTags>(_context));
            HashTagsNews = new MemoryRepository<HashTagsNews>(_context, new Repository<HashTagsNews>(_context));
            Categories = new MemoryRepository<Categories>(_context, new Repository<Categories>(_context));
            ArticlesViewForUI = new MemoryRepository<ArticlesViewForUI>(_context, new Repository<ArticlesViewForUI>(_context));

            Galleries = new MemoryRepository<Galleries>(_context, new Repository<Galleries>(_context));
            Users = new MemoryRepository<Users>(_context, new Repository<Users>(_context));
            
            Roles = new MemoryRepository<RoleModels>(_context, new Repository<RoleModels>(_context));
            UsersToRoles = new MemoryRepository<UsersToRoles>(_context, new Repository<UsersToRoles>(_context));
            
            PendingRegistration = new MemoryRepository<PendingRegistration>(_context, new Repository<PendingRegistration>(_context));

            //
            
        }

        private void RunMysqlDirectly(string connectionString, string script)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
    
                MySqlCommand command = new MySqlCommand(script, connection);
                command.ExecuteNonQuery();
    
                connection.Close();
            }
        }
        
        private  MemoryRepository<T> InitObjects<T>()  where T : Linq2DbEntity
        {
            return new MemoryRepository<T>(_context, new Repository<T>(_context));
        }

        public IMemoryRepository<ArticlesViewForUI> ArticlesViewForUI { get; private set; }
        public IMemoryRepository<Categories> Categories { get; private set; }
        public IMemoryRepository<HashTags> HashTags { get; private set; }
        public IMemoryRepository<HashTagsNews> HashTagsNews { get; private set; }
        public IMemoryRepository<NewsPublicationType> PublicationType { get; private set; }
        public IMemoryRepository<Galleries> Galleries { get; private set; }
        public IMemoryRepository<Users> Users { get; private set; }
        
        public IMemoryRepository<PendingRegistration> PendingRegistration { get; private set; }
        public IMemoryRepository<NewsEtty> News { get; private set; }
        public IMemoryRepository<RoleModels> Roles { get;  private set;}
        public IMemoryRepository<UsersToRoles> UsersToRoles { get;  private set; }

     
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
            var serviceProvider = CreateServices(_connectionString);
            
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

        private void RunManualMigration()
        {
            
        }


        private IServiceProvider CreateServices(string connection)
        {

            return new ServiceCollection()// Add common FluentMigrator services
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    // Add SQLite support to FluentMigrator
                    .AddMySql5()
                    
                    // Set the connection string
                    .WithGlobalConnectionString(connection)
                    // Define the assembly containing the migrations
                    //.ScanIn(typeof(UoWRepo.Migrations.AddNewColumnVersionOfNews).Assembly).For.Migrations()
                    .ScanIn(System.Reflection.Assembly.GetExecutingAssembly()).For.Migrations()
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
                //runner.MigrateUp();
                runner.Up(new AddUIViewArticles());
                runner.Up(new AddNewColumnVersionOfNews());
                runner.Up(new UpdateDomainUsers());
            }

        }

        
    }
}
