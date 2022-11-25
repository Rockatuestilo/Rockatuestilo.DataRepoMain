using LinqToDB;
using LinqToDB.DataProvider;
using UoWRepo.Core.Domain;

namespace UoWRepo.Core.Configuration
{
    public class Linq2DbContext: LinqToDB.Data.DataConnection, ICommonContext
    {
        public Linq2DbContext(string connectionString) : base(connectionString) { }

        public Linq2DbContext(string providerName, string connectionString) : base(providerName, connectionString) { }

        public Linq2DbContext(IDataProvider dataProvider, string connectionString) : base(dataProvider, connectionString) { }

        public ITable<ArticlesViewForUI> ArticlesViewForUI { get; private set; }

        public ITable<NewsEtty> tb_news { get; private set; }

        public ITable<Galleries> Galleries { get; private set; }
        
        public ITable<Users> Users { get; private set; }
        public ITable<Categories> Categories { get; private set; }

        public ITable<HashTags> HashTags { get; private set; }
        public ITable<HashTagsNews> HashtagsNews { get; private set; }

        public ITable<SharingSocialNetworkLinqDB> SharingSocialNetwork { get; private set; }

        public ITable<SharedObjectLinqDB> SharedObject { get; private set; }

        public ITable<NewsPublicationType> NewsPublicationType { get; private set; }
        
        public ITable<PendingRegistration> PendingRegistration { get; private set; }
        
        
        public ITable<RoleModels> RoleModels { get; private set; }
        
        public ITable<UsersToRoles> UsersToRoles { get; private set; }
    }
}
