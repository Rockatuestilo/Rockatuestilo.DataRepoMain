using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.Configuration;

namespace Rockatuestilo.DataRepoMain.Tests.DbInit
{
    public class ContextGenerator
    {
        public EFContext Create()
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                .UseInMemoryDatabase(databaseName: "Test").Options;

            var context = new EFContext(options);
                

            return context;
        }
    }
}