using System.Collections.Generic;
using System.Linq;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.LinqDomain;

namespace UoWRepo.Persistence.UnitiesOfWork;

public class ArticlesHomeUnityOfWork
{
    private readonly Linq2DbContext context;

    public ArticlesHomeUnityOfWork(Linq2DbContext context)
    {
        this.context = context;
    }


    public IEnumerable<NewsEtty> GetArticlesPerPageByHashtag(string hashtag, int userLevel, int currentPage,
        int pageSize)
    {
        /*var types = context.NewsPublicationType.Where(x => x.Leveluser <= userLevel);
            ResultArticles = (from p in ResultArticles
                              join t in types on p.Publicationtype equals t.Id
                              select new { p }).Select(x => x.p);*/

        var arts =
        (
            from ht in context.HashTags
            join ntN in context.HashtagsNews on ht.Id equals ntN.HashtagId
            join articles in context.tb_news on ntN.NewsId equals articles.Id
            join publictaionTypes in context.NewsPublicationType on articles.PublicationType equals publictaionTypes.Id
            where ht.HashtagWord == hashtag
            where publictaionTypes.LevelUser <= userLevel
            select new { articles }).Skip(pageSize * currentPage).Take(pageSize).Select(x => x.articles).ToList();

        return arts;
    }
}