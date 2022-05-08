using System.IO;
using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.Configuration;

namespace Rockatuestilo.DataRepoMain.Tests.DbInit
{
    public class ContextGenerator
    {
        private readonly string _nameOfFileforDatabase;
        
        public ContextGenerator()
        {
            
        }


        public ContextGenerator(string nameOfFileforDatabase)
        {
            _nameOfFileforDatabase = nameOfFileforDatabase;
        }

        public (Linq2DbContext, string) CreateLinq2DbSqlite()
        {
            if (File.Exists(_nameOfFileforDatabase))
            {
                File.Delete(_nameOfFileforDatabase);
            }

            var generationScript = CreateEFSqliteAndGetGenerationScript();
            var linq2DbContext=  new Linq2DbContext ("SQLite", $"Data Source={_nameOfFileforDatabase}");
            
            
            using (var db = new Linq2DbContext("SQLite", $"Data Source={_nameOfFileforDatabase}"))
            {
                var usersList = db.Query<dynamic>(generationScript);
            }
            

            return (linq2DbContext, generationScript);
        }
        
        public string CreateEFSqliteAndGetGenerationScript()
        {
            
            DbContextOptionsBuilder<EFContext> options = new DbContextOptionsBuilder<EFContext>();
            options.UseSqlite($"Data Source={_nameOfFileforDatabase}");
            
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
        
        
        public EFContext CreateInMysql()
        {
            //var options = new DbContextOptionsBuilder<EFContext>().
                
            var context = new EFContext("Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;charset=utf8;SslMode=none;Convert Zero Datetime=True; Pooling=true;");
            //Server=localhost;Port=3306;Database=cmsbackup5;Uid=cms;Pwd=albanicus$5$;ConnectionTimeout=600;DefaultCommandTimeout=600;SslMode=None;Pooling=true;
                

            return context;
        }
    }
}