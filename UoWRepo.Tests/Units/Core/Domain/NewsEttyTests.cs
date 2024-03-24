using UoWRepo.Core.BaseDomain;
using NewsEttyLinq2DB = UoWRepo.Core.Domain.NewsEtty; // Adjust namespace based on your project structure
using NewsEttyEfCore = UoWRepo.Core.EFDomain.NewsEtty;

namespace UoWRepo.Tests.Units.Core.Domain;

public class NewsEttyTests
{
    public INewsEtty GetHashTagVersion1()
    {
        return new NewsEttyLinq2DB
        {
            Id = 1,
            NewsTitle = "test",
            UserIdOwner = 1,
            NewsContent = "test",
            CreatedDate = new DateTime(2024, 3, 24),
            UpdatedDate = new DateTime(2024, 3, 24),
            NewsPermission = 1,
            NewsChangedById = 1,
            CategoryId = 1,
            PublicationType = 1,
            GalleryId = 1,
            NewsPresentation = "test",
            PublicationDate = new DateTime(2024, 3, 24),
            TitleForUrl = "test",
            HashtagsNewsId = 1
            
        };
    }
        
    public INewsEtty GetHashTagVersion2()
    {
        return new NewsEttyEfCore
        {
            Id = 1,
            NewsTitle = "test",
            UserIdOwner = 1,
            NewsContent = "test",
            CreatedDate = new DateTime(2024, 3, 24),
            UpdatedDate = new DateTime(2024, 3, 24),
            NewsPermission = 1,
            NewsChangedById = 1,
            CategoryId = 1,
            PublicationType = 1,
            GalleryId = 1,
            NewsPresentation = "test",
            PublicationDate = new DateTime(2024, 3, 24),
            TitleForUrl = "test",
            HashtagsNewsId = 1
        };
    }

    
    [Test]
    public void CheckPropertiesEquality()
    {
            
        DomainCommonTests domainCommonTests = new DomainCommonTests();
            
        // Arrange
        var hashTagV1 = GetHashTagVersion1();
        var hashTagV2 = GetHashTagVersion2();
            
        domainCommonTests.CheckPropertiesEquality(hashTagV1, hashTagV2);
    }
}