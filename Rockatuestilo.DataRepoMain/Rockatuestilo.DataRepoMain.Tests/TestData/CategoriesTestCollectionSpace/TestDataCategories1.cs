using System;
using UoWRepo.Core.EFDomain;

namespace Rockatuestilo.DataRepoMain.Tests.TestData.CategoriesTestCollectionSpace;

public class TestDataCategories1
{
    public Categories CreateFirstCategory()
    {
        var categories = new Categories();

        categories.CategoryName = "Conciertos";
        categories.CategoryOwner = 0;
        categories.CreatedById = 0;
        categories.CreatedDate = DateTime.Now;
        categories.LevelCategory = 0;
        categories.UpdatedById = 0;
        categories.UpdatedDate = DateTime.Now;

        return categories;
    }
}