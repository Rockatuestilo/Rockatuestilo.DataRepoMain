using System;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain;

[Table(Name = "tb_news")]
public class NewsEtty : Linq2DbEntity, INewsEtty, IBaseTEntity
{
    [Column(Name = "ArticleVersion")]
    [Nullable]
    public int? ArticleVersion { get; set; }

    [PrimaryKey]
    [Identity]
    [Column(Name = "newsID")]
    [NotNull]
    public new int Id { get; set; }

    [Column(Name = "newsOwner")] 
    [NotNull] public int UserIdOwner { get; set; }

    [StringLength(2000)]
    [Column(Name = "newsTittel")]
    [Nullable]
    public string? NewsTitle { get; set; }

    [Column(Name = "newsContent")]
    [Nullable]
    public string? NewsContent { get; set; }

    [Column(Name = "newsCreatedDate")]
    [NotNull]
    public new DateTime CreatedDate { get; set; }

    [Column(Name = "newsLastUpdateDate")]
    [NotNull]
    public new DateTime UpdatedDate { get; set; }

    [Column(Name = "newsPermission")]
    [Nullable]
    public int? NewsPermission { get; set; }

    [Column(Name = "newsChangedByID")]
    [Nullable]
    public int? NewsChangedById { get; set; }

    [Column(Name = "category_id")]
    [Nullable]
    public int? CategoryId { get; set; }

    [Column(Name = "publicationType")]
    [Nullable]
    public int? PublicationType { get; set; } = 0;

    [Column(Name = "galleryID")]
    [Nullable]
    public int? GalleryId { get; set; }

    [StringLength(2000)]
    [Column(Name = "newsPresentation")]
    [Nullable]
    public string? NewsPresentation { get; set; }

    [Column(Name = "publicationdate")]
    [NotNull]
    public DateTime PublicationDate { get; set; }

    [StringLength(500)]
    [Column(Name = "titleforURL")]
    [Nullable]
    public string? TitleForUrl { get; set; }

    [Column(Name = "HashtagsNewsId")]
    [Nullable]
    public int? HashtagsNewsId { get; set; }
}
