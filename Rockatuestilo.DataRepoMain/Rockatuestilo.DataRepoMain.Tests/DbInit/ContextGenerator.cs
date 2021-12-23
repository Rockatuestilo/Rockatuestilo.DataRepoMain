using LinqToDB.Data;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.Configuration;

namespace Rockatuestilo.DataRepoMain.Tests.DbInit
{
    public class ContextGenerator
    {
        
        
        public Linq2DbContext CreateLinq2DbSqlite()
        {
            CreateEFSqlite();
            return new Linq2DbContext ("SQLite", "Data Source=test.sqlite3");
        }
        
        public EFContext CreateEFSqlite()
        {
            
            DbContextOptionsBuilder<EFContext> options = new DbContextOptionsBuilder<EFContext>();
            options.UseSqlite("Data Source=test.sqlite3");
            EFContext tourManagerContext = new EFContext(options.Options);


            return tourManagerContext;
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