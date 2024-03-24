using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain;

[Table("Articles")] // Updated table name to Articles
public class ArticleDataModel : TEntity, IArticleDataModel, ITEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("ID")] // Updated column name to ID
    public new int Id { get; set; }
    
    [Column("Owner")] // Updated column name to Owner
    public int OwnerId { get; set; } // Updated property name to OwnerId

    [StringLength(2000)]
    [Column("Title")] // Updated column name to Title
    public string? Title { get; set; } // Updated property name to Title

    [Column("Content")] // Updated column name to Content
    public string? Content { get; set; } // Updated property name to Content

    [Column("Permission")] // Updated column name to Permission
    public int? Permission { get; set; } // Updated property name to Permission

    [Column("ChangedByID")] // Updated column name to ChangedByID
    public int? ChangedById { get; set; } // Updated property name to ChangedById

    [Column("CategoryID")] // Updated column name to CategoryID
    public int? CategoryId { get; set; } // Updated property name to CategoryId

    [Column("PublicationType")] // Column name PublicationType remains unchanged
    public int? PublicationType { get; set; } = 0; // No change needed

    [Column("GalleryID")] // Updated column name to GalleryID
    public int? GalleryId { get; set; } // Updated property name to GalleryId

    [StringLength(2000)]
    [Column("Presentation")] // Updated column name to Presentation
    public string? Presentation { get; set; } // Updated property name to Presentation and made nullable

    [Column("PublicationDate")] // Updated column name to PublicationDate
    public DateTime PublicationDate { get; set; } // No change needed

    [StringLength(500)]
    [Column("TitleForUrl")] // Corrected and updated column name to TitleForUrl
    public string? TitleForUrl { get; set; } // Updated property name to TitleForUrl and made nullable

    [Column("HashtagsId")] // Updated column name to HashtagsId
    public int? HashtagsId { get; set; } // Updated property name to HashtagsId

    [Column("ArticleVersion")] // Column name ArticleVersion remains unchanged
    public string? ArticleVersion { get; set; } // Assuming ArticleVersion is a string based on the previous correction. Update type if necessary.

    [Column("CreatedDate")] // Column name CreatedDate remains unchanged
    public DateTime CreatedDate { get; set; } // No change needed

    [Column("LastUpdateDate")] // Updated column name to LastUpdateDate
    public new DateTime UpdatedDate { get; set; } // No change needed
}