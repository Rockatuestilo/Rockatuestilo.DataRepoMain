using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Core.Configuration;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.Linq2Db;

// Proto class for NewsEtty model of Linq2Db
public class NewsEttyCrudsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup602;Uid=root;Pwd=blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;sqlservermode=True;SslMode=None;Pooling=true;";
        
        /*var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        //(Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();
        
        Linq2DbContext value = new ContextGenerator(connection).CreateInMysqlLinq2Db(connection);

        _unitOfWork = new UnityOfWork(value);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void GetAll1()
    {
        // get all news 
        var listOfNews = _unitOfWork.News.GetAll().ToList();

        
        Assert.Greater(listOfNews.Count, 0);
    }
}

// Proto class for ArticlesViewForUI model of Linq2Db
public class ArticlesViewForUICrudsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup602;Uid=root;Pwd=blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;sqlservermode=True;SslMode=None;Pooling=true;";
        
        /*var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        //(Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();
        
        Linq2DbContext value = new ContextGenerator(connection).CreateInMysqlLinq2Db(connection);

        _unitOfWork = new UnityOfWork(value);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void GetAll1()
    {
        // get all news 
        var listOfNews = _unitOfWork.ArticlesViewForUI.GetAll().ToList();

        
        Assert.NotNull(listOfNews);
    }
}

// Proto class for Categories model of Linq2Db
public class CategoriesCrudsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup602;Uid=root;Pwd=blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;sqlservermode=True;SslMode=None;Pooling=true;";
        
        /*var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        //(Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();
        
        Linq2DbContext value = new ContextGenerator(connection).CreateInMysqlLinq2Db(connection);

        _unitOfWork = new UnityOfWork(value);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void GetAll1()
    {
        // get all news 
        var listOfNews = _unitOfWork.Categories.GetAll().ToList();

        
        Assert.Greater(listOfNews.Count, 0);
    }
}

// Proto class for Galleries model of Linq2Db
public class GalleriesCrudsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup602;Uid=root;Pwd=blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;sqlservermode=True;SslMode=None;Pooling=true;";
        
        /*var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        //(Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();
        
        Linq2DbContext value = new ContextGenerator(connection).CreateInMysqlLinq2Db(connection);

        _unitOfWork = new UnityOfWork(value);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void GetAll1()
    {
        // get all news 
        var listOfNews = _unitOfWork.Galleries.GetAll().ToList();

        
        Assert.Greater(listOfNews.Count, 0);
    }
}

// Proto class for HashTags model of Linq2Db (please copilot, now you can do it)
public class HashtagsCrudsLinq2Db
{
    [SetUp]
    public void Setup()
    {
        
        var connection =
            "Server=localhost;Port=3306;Database=cmsbackup602;Uid=root;Pwd=blueberrywater4;ConnectionTimeout=600;DefaultCommandTimeout=600; Convert Zero Datetime=True;sqlservermode=True;SslMode=None;Pooling=true;";
        
        /*var value_0 = new ContextGenerator(connection).CreateInMysql();
        
        var value = new ContextGenerator(connection).CreateInMysqlLinq2Db();*/
        
        //(Linq2DbContext, string) value = new ContextGenerator("mydb.db").CreateLinq2DbSqlite();
        
        Linq2DbContext value = new ContextGenerator(connection).CreateInMysqlLinq2Db(connection);

        _unitOfWork = new UnityOfWork(value);
            
    }
    
    private IUnitOfWork _unitOfWork;
    
    [Test]
    public void GetAll1()
    {
        // get all news 
        var listOfNews = _unitOfWork.HashTags.GetAll().ToList();

        
        Assert.Greater(listOfNews.Count, 0);
    }
}

