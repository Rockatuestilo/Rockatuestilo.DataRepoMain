using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Tools.Contexts;

public class ContextCreator
{
    public static IUnitOfWorkEf CreateContextEFCoreInMemory()
    {
        var value = new ContextGenerator().CreateInMemory();
        return new UnityOfWorkEf(value);
    }
    
    public static IUnitOfWorkEf CreateContextEFCoreInSqlite(string fileName = "test.db")
    {
        var value = new ContextGenerator().CreateInSqlite(fileName);
        return new UnityOfWorkEf(value);
    }
    
    public static IUnitOfWorkEf CreateContextEFCoreInMysql(string connectionString)
    {
        var value = new ContextGenerator().CreateInMysql(connectionString);
        return new UnityOfWorkEf(value);
    }
}