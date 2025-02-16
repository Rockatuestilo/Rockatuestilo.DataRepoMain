using System;

namespace UoWRepo.Core.BaseDomain;

public interface IArticleDataModel : IBaseTEntity
{
    public int OwnerId { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? Permission { get; set; }

    public int? ChangedById { get; set; }

    public int? CategoryId { get; set; }

    public int? PublicationType { get; set; }

    public int? GalleryId { get; set; }

    public string Presentation { get; set; }

    public DateTime PublicationDate { get; set; }

    public string TitleForUrl { get; set; }

    public int? HashtagsArticleId { get; set; }

    public int? ArticleVersion { get; set; } // Assuming version could be a string like "1.0", "2.0", etc.
}