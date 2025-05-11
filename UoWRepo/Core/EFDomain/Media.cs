using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.EFDomain;

[Table("Media")]
// Inherits: Guid (PK), CreatedDate, UpdatedDate
public class Media : TEntityGuid
{
    [Required]
    [StringLength(500)]
    [Column("FilePath")]
    public string FilePath { get; set; } = null!;

    [Required]
    [Column("MediaType")]
    public string MediaType { get; set; } = null!; // e.g. "Image", "Video"

    [StringLength(255)]
    [Column("License")]
    public string? License { get; set; }

    [StringLength(500)]
    [Column("Copyright")]
    public string? Copyright { get; set; }

    [Column("Description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("FileSize")]
    public int? FileSize { get; set; }

    [Column("UploadedByGuid")]
    public Guid? UploadedByGuid { get; set; }
    // public virtual Users? UploadedByUser { get; set; }

    // --- Foreign Key to Authors ---
    [Column("AuthorGuid")]
    public Guid? AuthorGuid { get; set; }

    [ForeignKey(nameof(AuthorGuid))]
    [InverseProperty(nameof(Authors.MediaItems))]
    public virtual Authors? Author { get; set; }

    // --- Navigation collections ---

    [InverseProperty(nameof(SubjectMedia.Media))]
    public virtual ICollection<SubjectMedia>? SubjectMediaItems { get; set; }

    [InverseProperty(nameof(ArticleMedia.Media))]
    public virtual ICollection<ArticleMedia>? ArticleMediaItems { get; set; }
}