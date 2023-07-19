namespace UoWRepo.Core.Configuration.DbType;

public class Linq2DbContextCreator
{
    public Linq2DbContext CreateLinq2DbContext(LinqDatabaseType linqDatabaseType, string connectionString)
    {
        switch (linqDatabaseType)
        {
            case LinqDatabaseType.SQLite:
                return new Linq2DbContext("System.Data.SQLite", connectionString);
            case LinqDatabaseType.MySQL:
                return new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
            default:
                return new Linq2DbContext("MySql.Data.MySqlClient", connectionString);
        }
    }
}