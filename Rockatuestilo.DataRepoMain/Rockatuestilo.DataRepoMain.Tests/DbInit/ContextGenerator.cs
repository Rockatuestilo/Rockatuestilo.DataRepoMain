using System;
using System.IO;
using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.Configuration;

namespace Rockatuestilo.DataRepoMain.Tests.DbInit;

public class ContextGenerator
{
    private readonly string _nameOfFileForDatabaseOrStringConnection;

    public ContextGenerator()
    {
    }
    
    public ContextGenerator(string nameOfFileForDatabaseOrStringConnection)
    {
        _nameOfFileForDatabaseOrStringConnection = nameOfFileForDatabaseOrStringConnection;
    }

    private static bool Created = false;
    
    public (Linq2DbContext, string) CreateContextAndStringByEnvironment(string environment = "SQLite")
    {
        
        
        environment = environment.ToLower();
        
        if (environment == "SQLite".ToLower())
        {
            return CreateLinq2DbSqlite();
        }
        else if (environment == "MySQL".ToLower())
        {
            
            
            return CreateLinq2DbMysql();
        }
        /*else if (environment == "InMemory")
        {
            return CreateInMemoryLinq2Db();
        }*/
        
        return CreateLinq2DbSqlite();
    }

    private (Linq2DbContext, string) CreateLinq2DbMysql()
    {
        var cc = "server=localhost;user=root;password=blueberrywater4;database=cmsbackup604_test;Pooling=true;";
        if (Created)
        {
            var linq2DbContext_ = new Linq2DbContext("MySql.Data.MySqlClient",$"{cc}");
        
            return (linq2DbContext_, "");
        }

        Created = true;
        
        var generationScript = CreateAndGetGenerationScriptForMySQL();
        
       
        
        
        /*using (var db = new Linq2DbContext("MySql.Data.MySqlClient",$"{cc}"))
        {
            var usersList = db.Query<dynamic>(generationScript);
        }*/
        
        var linq2DbContext = new Linq2DbContext("MySql.Data.MySqlClient",$"{cc}");
        
        return (linq2DbContext, generationScript);
    }


    public (Linq2DbContext, string) CreateLinq2DbSqlite()
    {
        if (File.Exists(_nameOfFileForDatabaseOrStringConnection)) File.Delete(_nameOfFileForDatabaseOrStringConnection);

        var generationScript = CreateAndGetGenerationScriptForEFSqlite();
        var linq2DbContext = new Linq2DbContext("SQLite", $"Data Source={_nameOfFileForDatabaseOrStringConnection}");


        using (var db = new Linq2DbContext("SQLite", $"Data Source={_nameOfFileForDatabaseOrStringConnection}"))
        {
            var usersList = db.Query<dynamic>(generationScript);
        }


        return (linq2DbContext, generationScript);
    }

    public string CreateAndGetGenerationScriptForEFSqlite()
    {
        var options = new DbContextOptionsBuilder<EFContext>();
        options.UseSqlite($"Data Source={_nameOfFileForDatabaseOrStringConnection}");

        var tourManagerContext = new EFContext(options.Options);

        var generateScript = tourManagerContext.Database.GenerateCreateScript();


        return generateScript;
    }
    
    public string CreateAndGetGenerationScriptForMySQL()
    {
        var connectionString = "server=localhost;user=root;password=blueberrywater4;database=cmsbackup604_test";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        
        var options = new DbContextOptionsBuilder<EFContext>();
        /*options.UseMySql(
            ServerVersion.AutoDetect(
                "Server=localhost;Port=3306;Database=cmsbackup604;user=root;password=blueberrywater4"));*/

        options.UseMySql(connectionString, serverVersion);
            
            

        var tourManagerContext = new EFContext(options.Options);

        var canConnect = tourManagerContext.Database.CanConnect();

        tourManagerContext.Database.EnsureDeleted();

        var generateScridpt = tourManagerContext.Database.EnsureCreated();
        var generateScript = tourManagerContext.Database.GenerateCreateScript();
        
        generateScript = generateScript.Replace("ALTER DATABASE", "CREATE DATABASE");


        return generateScript;
    }


    public EFContext CreateInMemory()
    {
        var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase("Test").Options;

        var context = new EFContext(options);


        return context;
        //return CreateInMysql();
    }


    public Linq2DbContext CreateInMysqlLinq2Db()
    {
        //var options = new DbContextOptionsBuilder<EFContext>().


        var context = new Linq2DbContext("MySql.Data.MySqlClient",
            "Server=localhost;Port=13306;Database=test;Uid=root;Pwd=password;charset=utf8;SslMode=Required;Convert Zero Datetime=True; Pooling=true;");

        //Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;ConnectionTimeout=600;DefaultCommandTimeout=600;SslMode=None;Pooling=true;


        return context;
    }


    public EFContext CreateInMysql()
    {
        //var options = new DbContextOptionsBuilder<EFContext>().
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup_test;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";


        /*var context =
            new EFContext(
                "Server=localhost;Port=13306;Database=cmsbackup_tests;Uid=root;Pwd=password;charset=utf8;SslMode=Required;Convert Zero Datetime=True; Pooling=true;");#
            */
            
            
            
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 31));
        
        var options = new DbContextOptionsBuilder<EFContext>();
        /*options.UseMySql(
            ServerVersion.AutoDetect(
                "Server=localhost;Port=3306;Database=cmsbackup604;user=root;password=blueberrywater4"));*/

        options.UseMySql(connection, serverVersion);
            
            

        var tourManagerContext = new EFContext(options.Options);
        
        tourManagerContext.Database.EnsureDeleted();
        tourManagerContext.Database.EnsureCreated();
        //Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;ConnectionTimeout=600;DefaultCommandTimeout=600;SslMode=None;Pooling=true;


        return tourManagerContext;
    }
}