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

        public ITable<ArticlesViewForUI> ArticlesViewForUI { get { return GetTable<ArticlesViewForUI>(); } }

        public ITable<NewsEtty> tb_news { get { return GetTable<NewsEtty>(); } }

        public ITable<Galleries> Galleries { get { return GetTable<Galleries>(); } }

        public ITable<Users> Users { get { return GetTable<Users>(); } }

        public ITable<Categories> Categories { get { return GetTable<Categories>(); } }

        public ITable<HashTags> HashTags { get { return GetTable<HashTags>(); } }

        public ITable<HashTagsNews> HashtagsNews { get { return GetTable<HashTagsNews>(); } }

        public ITable<SharingSocialNetworkLinqDB> SharingSocialNetwork { get { return GetTable<SharingSocialNetworkLinqDB>(); } }

        public ITable<SharedObjectLinqDB> SharedObject { get { return GetTable<SharedObjectLinqDB>(); } }

        public ITable<NewsPublicationType> NewsPublicationType { get { return GetTable<NewsPublicationType>(); } }
        
        public ITable<PendingRegistration> PendingRegistration { get { return GetTable<PendingRegistration>(); } }
    }
}
