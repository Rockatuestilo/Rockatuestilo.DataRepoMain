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

    public UnityOfWorkLinq(Linq2DbContext context)
    {
        _context = context;
        //new MigrationsModule(_context.ConfigurationString).DoSomeMigration();
        new RunFirstMigration(context);
        //RunStupidMigration();
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

        //
    }

    public IRepository<PendingRegistration> PendingRegistration { get; private set; }

    public IRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
    public IRepository<Categories> Categories { get; }
    public IRepository<HashTags> HashTags { get; }
    public IRepository<HashTagsNews> HashTagsNews { get; }
    public IRepository<NewsPublicationType> PublicationType { get; }
    public IRepository<Galleries> Galleries { get; }
    public IRepository<Users> Users { get; }
    public IRepository<NewsEtty> News { get; }
    public IRepository<RoleModels> Roles { get; }
    public IRepository<UsersToRoles> UsersToRoles { get; }


    public int Complete()
    {
        if (_context.Transaction != null)
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