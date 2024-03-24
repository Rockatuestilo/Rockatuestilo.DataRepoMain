using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider;
using UoWRepo.Core.Domain;

namespace UoWRepo.Core.Configuration;




public class Linq2DbContext : DataConnection, ICommonContext
{
   
    public Linq2DbContext(string providerName, string connectionString) : base(providerName, connectionString)
    {
    }

    public Linq2DbContext(IDataProvider dataProvider, string connectionString) : base(dataProvider, connectionString)
    {
    }

    public ITable<ArticlesViewForUi> ArticlesViewForUI => this.GetTable<ArticlesViewForUi>();

    public ITable<NewsEtty> tb_news => this.GetTable<NewsEtty>();
    
    public ITable<ArticleDataModel> ArticleDataModel => this.GetTable<ArticleDataModel>();

    public ITable<Galleries> Galleries => this.GetTable<Galleries>();

    public ITable<Users> Users => this.GetTable<Users>();

    public ITable<Categories> Categories => this.GetTable<Categories>();

    public ITable<HashTags> HashTags => this.GetTable<HashTags>();

    public ITable<HashTagsNews> HashtagsNews => this.GetTable<HashTagsNews>();

    public ITable<SharingSocialNetworkLinqDB> SharingSocialNetwork => this.GetTable<SharingSocialNetworkLinqDB>();

    public ITable<SharedObjectLinqDB> SharedObject => this.GetTable<SharedObjectLinqDB>();

    public ITable<NewsPublicationType> NewsPublicationType => this.GetTable<NewsPublicationType>();

    public ITable<PendingRegistration> PendingRegistration => this.GetTable<PendingRegistration>();

    public ITable<RoleModels> Roles => this.GetTable<RoleModels>();

    public ITable<UsersToRoles> UsersToRoles { get; private set; }

    // method for rawsql
    public T ExecuteRaw<T>(string sql)
    {
        return this.Execute<T>(sql);
    }
}