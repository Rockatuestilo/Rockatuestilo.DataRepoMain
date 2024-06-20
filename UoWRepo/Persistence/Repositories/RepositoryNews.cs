using System;
using System.Collections.Generic;
using System.Linq;
using LinqToDB;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.LinqDomain;
using UoWRepo.Core.Repositories;

namespace UoWRepo.Persistence.Repositories;

[Obsolete]

public class RepositoryNews : Repository<NewsEtty>, IRepositoryNews
{
    public RepositoryNews(Linq2DbContext context) : base(context)
    {
    }

    public IEnumerable<NewsEtty> GetArticlesByTags(string tagLowered)
    {
        var result = (from hashtags in _context.HashTags
            join HashTagsNews in _context.HashtagsNews on hashtags.Id equals HashTagsNews.HashtagId
            join tb_news in _context.tb_news on HashTagsNews.NewsId equals tb_news.Id
            where hashtags.HashtagWord.ToLower() == tagLowered
            select tb_news).ToList();

        return result;
    }


    public new void Update(NewsEtty entity)
    {
        _context.BeginTransaction();
        _context.Update(entity);
        _context.ArticlesViewForUI.Where(x => x.ArticleId == entity.Id).Delete();
    }

    public IEnumerable<NewsEtty> GetPagesOfNews(int pageIndex, int pageSize = 10)
    {
        return _context.tb_news.Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();
    }

    public void UpdatePublicationTime(int articleID, DateTime datetime)
    {
        _context.tb_news.Where(x => x.Id == articleID)
            .Set(p => p.PublicationDate, DateTime.Now)
            .Update();
    }
}