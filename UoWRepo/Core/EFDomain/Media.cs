using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.EFDomain;

[Table("Media")]
// Inheriting BaseGuidTEntity assumes Guid, CreatedDate, UpdatedDate exist and map correctly
public class Media : TEntityGuid
{
    // Inherited: Guid (PK), CreatedDate, UpdatedDate

    [Required]
    [StringLength(500)] // Match DDL varchar length
    [Column("FilePath")]
    public string FilePath { get; set; } = null!;

    [Required]
    [Column("MediaType")]
    // Consider using an actual Enum type in C# and configuring EF Core
    // to convert it to/from string if preferred over raw string.
    public string MediaType { get; set; } = null!; // Enum values like 'Image', 'Video', etc.

    [StringLength(255)] // Match DDL varchar length
    [Column("Author")]
    public string? Author { get; set; } // This is the old free-text author, potentially obsolete

    [StringLength(255)] // Match DDL varchar length
    [Column("License")]
    public string? License { get; set; }

    // --- Newly Added Properties ---

    [StringLength(500)] // Match DDL varchar length
    [Column("Copyright")]
    public string? Copyright { get; set; }

    [Column("Description", TypeName = "text")] // Explicit type for TEXT
    public string? Description { get; set; }

    [Column("FileSize")]
    public int? FileSize { get; set; } // Nullable int

    [Column("UploadedByGuid")]
    // Optional: Add [ForeignKey("UploadedByUser")] if defining that navigation property
    public Guid? UploadedByGuid { get; set; } // Nullable Guid

    [Column("AuthorGuid")]
    [ForeignKey("AuthorRef")] // Link to the Authors navigation property below
    public Guid? AuthorGuid { get; set; } // Nullable Guid FK

    // --- Navigation Properties ---

    // Optional: Navigation property to the actual Author entity
    public virtual Authors? AuthorRef { get; set; }

    // Optional: Navigation property to the User who uploaded it
    // public virtual Users? UploadedByUser { get; set; }

    // Optional: Collection of SubjectMedia linking this Media to Subjects
    // public virtual ICollection<SubjectMedia>? SubjectLinks { get; set; }

    // Optional: Collection of ArticleMedia linking this Media to Articles
    // public virtual ICollection<ArticleMedia>? ArticleLinks { get; set; }
}