using System;
using MySql.Data.MySqlClient;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;
using UoWRepo.Migrations.Manual;
using UoWRepo.Persistence.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork;

public class UnityOfWorkLinq : IUnitOfWorkLinq
{
    private readonly Linq2DbContext _context;
    private readonly string _connectionString;

    public UnityOfWorkLinq(Linq2DbContext context)
    {
        _context = context;
        //new MigrationsModule(_context.ConfigurationString).DoSomeMigration();
        //new RunFirstMigration(context);
        //RunStupidMigration();
        InitProperties();
        

        //
    }
    
    
    public UnityOfWorkLinq(string connectionString)
    {
        _context = new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
        
        _connectionString = connectionString;
        //new MigrationsModule(_context.ConfigurationString).DoSomeMigration();
        //new RunFirstMigration(context);
        //RunStupidMigration();
        InitPropertiesConnectionString();
        

        //
    }
    
    private void InitPropertiesConnectionString()
    {
        News = new Repository<NewsEtty>(_connectionString);

        PublicationType =
            new Repository<NewsPublicationType>(_connectionString);
        HashTags = new Repository<HashTags>(_connectionString);
        HashTagsNews = new Repository<HashTagsNews>(_connectionString);
        Categories = new Repository<Categories>(_connectionString);
        ArticlesViewForUI =
            new Repository<ArticlesViewForUI>(_connectionString);

        Galleries = new Repository<Galleries>(_connectionString);
        Users = new Repository<Users>(_connectionString);

        Roles = new Repository<RoleModels>(_connectionString);
        UsersToRoles = new Repository<UsersToRoles>(_connectionString);

        PendingRegistration =
            new Repository<PendingRegistration>(_connectionString);
    }

    private void InitProperties()
    {
        News = new Repository<NewsEtty>(_context);

        PublicationType =
            new Repository<NewsPublicationType>(_context);
        HashTags = new Repository<HashTags>(_context);
        HashTagsNews = new Repository<HashTagsNews>(_context);
        Categories = new Repository<Categories>(_context);
        ArticlesViewForUI =
            new Repository<ArticlesViewForUI>(_context);

        Galleries = new Repository<Galleries>(_context);
        Users = new Repository<Users>(_context);

        Roles = new Repository<RoleModels>(_context);
        UsersToRoles = new Repository<UsersToRoles>(_context);

        PendingRegistration =
            new Repository<PendingRegistration>(_context);
    }

    public IRepository<PendingRegistration> PendingRegistration { get; private set; }

    public IRepository<ArticlesViewForUI> ArticlesViewForUI { get; private set;}
    public IRepository<Categories> Categories { get; private set;}
    public IRepository<HashTags> HashTags { get; private set;}
    public IRepository<HashTagsNews> HashTagsNews { get; private set;}
    public IRepository<NewsPublicationType> PublicationType { get; private set;}
    public IRepository<Galleries> Galleries { get; private set;}
    public IRepository<Users> Users { get; private set;}
    public IRepository<NewsEtty> News { get; private set;}
    public IRepository<RoleModels> Roles { get; private set;}
    public IRepository<UsersToRoles> UsersToRoles { get;private set; }


    public int Complete()
    {
        if (_context?.Transaction != null)
            try
            {
                _context.Transaction.Commit();
            }
            catch (Exception ex)
            {
                var hhh = ex.Message;
            }

        return 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    private void RunMysqlDirectly(string connectionString, string script)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();

            var command = new MySqlCommand(script, connection);
            command.ExecuteNonQuery();

            connection.Close();
        }
    }

    private Repository<T> InitObjects<T>() where T : Linq2DbEntity
    {
        return new Repository<T>(_context);
    }
}