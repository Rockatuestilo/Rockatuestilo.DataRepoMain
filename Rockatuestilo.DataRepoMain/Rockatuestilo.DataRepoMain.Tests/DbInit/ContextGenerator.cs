using System;
using System.IO;
//using LinqToDB.Data;
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
    
    public EFContext CreateInMemory(string dbName = "Test")
    {
        var options = new DbContextOptionsBuilder<EFContext>()
            .UseInMemoryDatabase(dbName).Options;
        var context = new EFContext(options);
        return context;
    }
    
    public EFContext CreateInSqlite(string fileName) 
    {
        if (File.Exists(fileName))
        {
            File.Delete(fileName);
        }

        
        var dbContextOptions = new DbContextOptionsBuilder<EFContext>()
            .UseSqlite($"Data Source={fileName}");
        
        var options = dbContextOptions.Options;
        
        
        var context = new EFContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }
    
    public EFContext CreateInMysql(string connectionString, Version? version = null)
    {
        //var options = new DbContextOptionsBuilder<EFContext>().
        
        var connection =
            "Server=localhost;Port=3306;charset=utf8;Database=BLAZARES_V1;charset=utf8;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";
        
        if(!string.IsNullOrEmpty(connectionString))
        {
            connection = connectionString;
        }


        /*var context =
            new EFContext(
                "Server=localhost;Port=13306;Database=cmsbackup_tests;Uid=root;Pwd=password;charset=utf8;SslMode=Required;Convert Zero Datetime=True; Pooling=true;");#
            */
            
        if(version == null)
        {
            version = new Version(8, 0, 31);
        }
        
            
            
        var serverVersion = new MySqlServerVersion(version);
        
        var options = new DbContextOptionsBuilder<EFContext>();
        /*options.UseMySql(
            ServerVersion.AutoDetect(
                "Server=localhost;Port=3306;Database=cmsbackup604;user=root;password=blueberrywater4"));*/

        options.UseMySql(connection, serverVersion);
            
            

        var tourManagerContext = new EFContext(options.Options);
        
        tourManagerContext.Database.EnsureDeleted();
        tourManagerContext.Database.EnsureCreated();
        return tourManagerContext;
    }
    
    public EFContext CreateInMysql()
    {
        //var options = new DbContextOptionsBuilder<EFContext>().
        
        var connection =
            "Server=localhost;Port=3306;charset=utf8;Database=BLAZARES_V1;charset=utf8;Uid=root;Pwd=blueberrywater4;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;";


            
            
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
        connectionString = _nameOfFileForDatabaseOrStringConnection;
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


  


    public Linq2DbContext CreateInMysqlLinq2Db()
    {
        //var options = new DbContextOptionsBuilder<EFContext>().


        var context = new Linq2DbContext("MySql.Data.MySqlClient",
            "Server=localhost;Port=13306;Database=test;Uid=root;Pwd=password;charset=utf8;SslMode=Required;Convert Zero Datetime=True; Pooling=true;");

        //Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;ConnectionTimeout=600;DefaultCommandTimeout=600;SslMode=None;Pooling=true;


        return context;
    }


   
}