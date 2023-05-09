using System.Configuration;
using LinqToDB;
using LinqToDB.Common;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using LinqToDB.Reflection;
using UoWRepo.Core.Domain;

namespace UoWRepo.Core.Configuration
{
    public class Linq2DbContext: LinqToDB.Data.DataConnection, ICommonContext
    {
        public Linq2DbContext(string connectionString) : base(connectionString) { }

        public Linq2DbContext(string providerName, string connectionString) : base(providerName, connectionString) { }

        public Linq2DbContext(IDataProvider dataProvider, string connectionString) : base(dataProvider, connectionString) { }

        public ITable<ArticlesViewForUI> ArticlesViewForUI { get { return this.GetTable<ArticlesViewForUI>(); } }

        public ITable<NewsEtty> tb_news { get { return this.GetTable<NewsEtty>(); } }

        public ITable<Galleries> Galleries { get { return this.GetTable<Galleries>(); } }

        public ITable<Users> Users { get { return this.GetTable<Users>(); } }

        public ITable<Categories> Categories { get { return this.GetTable<Categories>(); } }

        public ITable<HashTags> HashTags { get { return this.GetTable<HashTags>(); } }

        public ITable<HashTagsNews> HashtagsNews { get { return this.GetTable<HashTagsNews>(); } }

        public ITable<SharingSocialNetworkLinqDB> SharingSocialNetwork { get { return this.GetTable<SharingSocialNetworkLinqDB>(); } }

        public ITable<SharedObjectLinqDB> SharedObject { get { return this.GetTable<SharedObjectLinqDB>(); } }

        public ITable<NewsPublicationType> NewsPublicationType { get { return this.GetTable<NewsPublicationType>(); } }
        
        public ITable<PendingRegistration> PendingRegistration { get { return this.GetTable<PendingRegistration>(); } }
        
        public ITable<RoleModels> Roles { get { return this.GetTable<RoleModels>(); } }

        public ITable<UsersToRoles> UsersToRoles { get; private set; }
        
        // method for rawsql
        public T ExecuteRaw<T>(string sql)
        {
            
            return this.Execute<T>(sql);
        }
    }
}
