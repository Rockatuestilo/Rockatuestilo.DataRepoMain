using Microsoft.EntityFrameworkCore;

namespace UoWRepo.Core.Configuration.DbType;

public class EfCoreDbContextCreator
{
    public EFContext CreateLinq2DbContext(LinqDatabaseType linqDatabaseType, string connectionString)
    {
        DbContextOptions<EFContext> options;
        switch (linqDatabaseType)
        {
            case LinqDatabaseType.SQLite:
                
                options = new DbContextOptionsBuilder<EFContext>()
                    .UseSqlite($"Data Source={connectionString}")
                    .Options;
                return new EFContext(options);
            case LinqDatabaseType.MySQL:
                options = new DbContextOptionsBuilder<EFContext>()
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .Options;
                return new EFContext(options);
            default:
                options = new DbContextOptionsBuilder<EFContext>()
                    .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                    .Options;
                return new EFContext(options);
        }
    }
    
}