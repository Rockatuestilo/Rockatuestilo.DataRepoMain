﻿using System;
using System.Reflection;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.Repositories;
using UoWRepo.Migrations;
using UoWRepo.Migrations.Manual;
using UoWRepo.Persistence.Repositories;

namespace UoWRepo.Persistence.UnitiesOfWork;
//TODO: test this

public class UnityOfWork : IUnitOfWork
{
    private readonly Linq2DbContext _context;

    public UnityOfWork(Linq2DbContext context)
    {
        _context = context;
        //new MigrationsModule(_context.ConfigurationString).DoSomeMigration();
        new RunFirstMigration(context);
        //RunStupidMigration();
        News = new MemoryRepository<NewsEtty>(_context, new Repository<NewsEtty>(_context));

        PublicationType =
            new MemoryRepository<NewsPublicationType>(_context, new Repository<NewsPublicationType>(_context));
        HashTags = new MemoryRepository<HashTags>(_context, new Repository<HashTags>(_context));
        HashTagsNews = new MemoryRepository<HashTagsNews>(_context, new Repository<HashTagsNews>(_context));
        Categories = new MemoryRepository<Categories>(_context, new Repository<Categories>(_context));
        ArticlesViewForUI =
            new MemoryRepository<ArticlesViewForUI>(_context, new Repository<ArticlesViewForUI>(_context));

        Galleries = new MemoryRepository<Galleries>(_context, new Repository<Galleries>(_context));
        Users = new MemoryRepository<Users>(_context, new Repository<Users>(_context));

        Roles = new MemoryRepository<RoleModels>(_context, new Repository<RoleModels>(_context));
        UsersToRoles = new MemoryRepository<UsersToRoles>(_context, new Repository<UsersToRoles>(_context));

        PendingRegistration =
            new MemoryRepository<PendingRegistration>(_context, new Repository<PendingRegistration>(_context));

        //
    }

    public IMemoryRepository<PendingRegistration> PendingRegistration { get; private set; }

    public IMemoryRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
    public IMemoryRepository<Categories> Categories { get; }
    public IMemoryRepository<HashTags> HashTags { get; }
    public IMemoryRepository<HashTagsNews> HashTagsNews { get; }
    public IMemoryRepository<NewsPublicationType> PublicationType { get; }
    public IMemoryRepository<Galleries> Galleries { get; }
    public IMemoryRepository<Users> Users { get; }
    public IMemoryRepository<NewsEtty> News { get; }
    public IMemoryRepository<RoleModels> Roles { get; }
    public IMemoryRepository<UsersToRoles> UsersToRoles { get; }


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

    private MemoryRepository<T> InitObjects<T>() where T : Linq2DbEntity
    {
        return new MemoryRepository<T>(_context, new Repository<T>(_context));
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
            //runner.MigrateUp();
            runner.Up(new AddUIViewArticles());
            runner.Up(new AddNewColumnVersionOfNews());
            runner.Up(new UpdateDomainUsers());
        }
    }
}