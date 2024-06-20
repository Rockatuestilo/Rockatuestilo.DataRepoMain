using System;
using System.ComponentModel.DataAnnotations;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.LinqDomain;

[Table(Name = "Articles")] // Updated table name
public class ArticleDataModel : Linq2DbEntity, IArticleDataModel, IBaseTEntity
{
    [Column(Name = "ArticleVersion")]
    [StringLength(2)]
    [Nullable]
    public string? ArticleVersion { get; set; } // Assuming ArticleVersion is a string. Update type if necessary.

    [PrimaryKey, Identity]
    [Column(Name = "ID")] // Updated column name
    [NotNull]
    public new int Id { get; set; }

    [Column(Name = "Owner")] // Updated column name
    [NotNull] 
    public int OwnerId { get; set; } // Property name updated

    [StringLength(2000)]
    [Column(Name = "Title")] // Updated column name
    [Nullable]
    public string? Title { get; set; } // Property name updated

    [Column(Name = "Content")] // Updated column name
    [Nullable]
    public string? Content { get; set; } // Property name updated

    [Column(Name = "CreatedDate")] // Column name unchanged
    [NotNull]
    public new DateTime CreatedDate { get; set; } // Inherits correctly, no change needed

    [Column(Name = "LastUpdateDate")] // Updated column name
    [NotNull]
    public new DateTime UpdatedDate { get; set; } // Property name updated to match

    [Column(Name = "Permission")] // Updated column name
    [Nullable]
    public int? Permission { get; set; } // Property name updated

    [Column(Name = "ChangedByID")] // Updated column name
    [Nullable]
    public int? ChangedById { get; set; } // Property name updated

    [Column(Name = "CategoryID")] // Updated column name
    [Nullable]
    public int? CategoryId { get; set; } // Property name updated

    [Column(Name = "PublicationType")] // Column name unchanged
    [Nullable]
    public int? PublicationType { get; set; } // Inherits default value correctly, no change needed

    [Column(Name = "GalleryID")] // Updated column name
    [Nullable]
    public int? GalleryId { get; set; } // Property name updated

    [StringLength(2000)]
    [Column(Name = "Presentation")] // Updated column name
    [Nullable]
    public string? Presentation { get; set; } // Property name updated

    [Column(Name = "PublicationDate")] // Column name unchanged
    [NotNull]
    public DateTime PublicationDate { get; set; } // Inherits correctly, no change needed

    [StringLength(500)]
    [Column(Name = "TitleForUrl")] // Corrected and updated column name
    [Nullable]
    //[Unique] // Mark this field as unique. Note: [Unique] is not a standard DataAnnotations attribute. You may need a custom validation or handle it differently depending on your ORM.
    public string? TitleForUrl { get; set; } // Property name corrected and updated

    [Column(Name = "HashtagsArticleId")] // Updated column name
    [Nullable]
    public int? HashtagsArticleId { get; set; } // Property name updated
}