using System;
using NUnit.Framework;
using UoWRepo.Core.EFDomain;

namespace Rockatuestilo.DataRepoMain.Tests.Units.Fields;

[TestFixture]
public class NewsEttyTests
{
    [Test]
    public void Id_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 123;
        var news = new NewsEtty { Id = expected };

        // Act
        var actual = news.Id;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void UserIdOwner_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 456;
        var news = new NewsEtty { UserIdOwner = expected };

        // Act
        var actual = news.UserIdOwner;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void NewsTitle_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = "Test news title";
        var news = new NewsEtty { NewsTitle = expected };

        // Act
        var actual = news.NewsTitle;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void NewsContent_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = "Test news content";
        var news = new NewsEtty { NewsContent = expected };

        // Act
        var actual = news.NewsContent;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void NewsCreatedDate_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = DateTime.UtcNow;
        var news = new NewsEtty { CreatedDate = expected };

        // Act
        var actual = news.CreatedDate;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void UpdatedDate_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = DateTime.UtcNow;
        var news = new NewsEtty { UpdatedDate = expected };

        // Act
        var actual = news.UpdatedDate;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void NewsPermission_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 1;
        var news = new NewsEtty { NewsPermission = expected };

        // Act
        var actual = news.NewsPermission;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void NewsChangedById_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 789;
        var news = new NewsEtty { NewsChangedById = expected };

        // Act
        var actual = news.NewsChangedById;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void CategoryId_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 10;
        var news = new NewsEtty { CategoryId = expected };

        // Act
        var actual = news.CategoryId;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void PublicationType_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 1;
        var news = new NewsEtty { PublicationType = expected };

        // Act
        var actual = news.PublicationType;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void GalleryId_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 20;
        var news = new NewsEtty { GalleryId = expected };

        // Act
        var actual = news.GalleryId;

        // Assert
        Assert.AreEqual(expected, actual);
    }


    [Test]
    public void NewsPresentation_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = "Test news presentation";
        var news = new NewsEtty { NewsPresentation = expected };

        // Act
        var actual = news.NewsPresentation;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void PublicationDate_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = DateTime.UtcNow;
        var news = new NewsEtty { PublicationDate = expected };

        // Act
        var actual = news.PublicationDate;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void TitleForUrl_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        var expected = "test-news-url";
        var news = new NewsEtty { TitleForUrl = expected };

        // Act
        var actual = news.TitleForUrl;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void HashtagsNewsId_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        int? expected = 30;
        var news = new NewsEtty { HashtagsNewsId = expected };

        // Act
        var actual = news.HashtagsNewsId;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void ArticleVersion_GetSet_ReturnsExpectedValue()
    {
        // Arrange
        int? expected = 1;
        var news = new NewsEtty { ArticleVersion = expected };

        // Act
        var actual = news.ArticleVersion;

        // Assert
        Assert.AreEqual(expected, actual);
    }
}