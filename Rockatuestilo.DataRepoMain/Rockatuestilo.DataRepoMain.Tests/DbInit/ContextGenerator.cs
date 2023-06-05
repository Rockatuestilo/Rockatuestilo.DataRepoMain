using System.IO;
using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.Configuration;

namespace Rockatuestilo.DataRepoMain.Tests.DbInit
{
    public class ContextGenerator
    {
        private readonly string _nameOfFileForDatabase;
        
        public ContextGenerator()
        {
            
        }


        public ContextGenerator(string nameOfFileForDatabase)
        {
            _nameOfFileForDatabase = nameOfFileForDatabase;
        }

        public (Linq2DbContext, string) CreateLinq2DbSqlite()
        {
            if (File.Exists(_nameOfFileForDatabase))
            {
                File.Delete(_nameOfFileForDatabase);
            }

            var generationScript = CreateEFSqliteAndGetGenerationScript();
            var linq2DbContext=  new Linq2DbContext ("SQLite", $"Data Source={_nameOfFileForDatabase}");


            using (var db = new Linq2DbContext("SQLite", $"Data Source={_nameOfFileForDatabase}"))
            {
                var usersList = db.Query<dynamic>(generationScript);
            }
            

            return (linq2DbContext, generationScript);
        }
        
        public string CreateEFSqliteAndGetGenerationScript()
        {
            
            DbContextOptionsBuilder<EFContext> options = new DbContextOptionsBuilder<EFContext>();
            options.UseSqlite($"Data Source={_nameOfFileForDatabase}");
            
            EFContext tourManagerContext = new EFContext(options.Options);

            var generateScript = tourManagerContext.Database.GenerateCreateScript();


            return generateScript;
        }
        
        
        public EFContext CreateInMemory()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                .UseInMemoryDatabase(databaseName: "Test").Options;

            var context = new EFContext(options);
            
            
                

            return context;
            //return CreateInMysql();
        }
        
        
        public Linq2DbContext CreateInMysqlLinq2Db(string connectionString)
        {
            //var options = new DbContextOptionsBuilder<EFContext>().

     
                
            //var context = new Linq2DbContext("MySql.Data.MySqlClient", "Server=localhost;Port=13306;Database=test;Uid=root;Pwd=password;charset=utf8;SslMode=Required;Convert Zero Datetime=True; Pooling=true;");
            
            var context = new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
            
            //Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;ConnectionTimeout=600;DefaultCommandTimeout=600;SslMode=None;Pooling=true;
                

            return context;
        }
        
        
        public EFContext CreateInMysql()
        {
            //var options = new DbContextOptionsBuilder<EFContext>().
                
            var context = new EFContext("Server=localhost;Port=13306;Database=test;Uid=root;Pwd=password;charset=utf8;SslMode=Required;Convert Zero Datetime=True; Pooling=true;");
            context.Database.EnsureCreated();
            //Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;ConnectionTimeout=600;DefaultCommandTimeout=600;SslMode=None;Pooling=true;
                

            return context;
        }
    }
}