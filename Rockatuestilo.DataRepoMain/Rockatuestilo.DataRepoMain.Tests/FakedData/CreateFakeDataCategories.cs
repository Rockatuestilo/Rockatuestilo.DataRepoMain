using System.Collections.Generic;
using UoWRepo.Core.LinqDomain;

namespace Rockatuestilo.DataRepoMain.Tests.FakedData;

public class CreateFakeDataCategories
{
    public List<Categories> DoStatic()
    {
        var news = new Categories();
        news.CategoryName = "News";
        news.CategoryOwner = 0;
        news.LevelCategory = 0;

        var entrevistas = new Categories();
        entrevistas.CategoryName = "Entrevistas";
        entrevistas.CategoryOwner = 0;
        entrevistas.LevelCategory = 0;

        var reviews = new Categories();
        reviews.CategoryName = "Reviews";
        reviews.CategoryOwner = 0;
        reviews.LevelCategory = 0;

        var videos = new Categories();
        videos.CategoryName = "Videos";
        videos.CategoryOwner = 0;
        videos.LevelCategory = 0;

        var conciertos = new Categories();
        conciertos.CategoryName = "Conciertos";
        conciertos.CategoryOwner = 0;
        conciertos.LevelCategory = 0;

        var festivales = new Categories();
        festivales.CategoryName = "Festivales";
        festivales.CategoryOwner = 0;

        var list = new List<Categories>();
        list.Add(news);
        list.Add(entrevistas);
        list.Add(reviews);
        list.Add(videos);
        list.Add(conciertos);
        list.Add(festivales);

        return list;
    }
}