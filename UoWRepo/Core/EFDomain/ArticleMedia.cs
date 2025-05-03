using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain; 

[Table("ArticleMedia")]
public class ArticleMedia : TEntityGuid  
{
    // Composite Primary Key is typically configured using Fluent API in DbContext,
    // not with [Key] attributes here.

    [Required]
    [Column("ArticleGuid")]
    public Guid ArticleGuid { get; set; }

    [Required]
    [Column("MediaGuid")]
    public Guid MediaGuid { get; set; }

    [StringLength(50)]
    [Column("MediaRole")]
    public string? MediaRole { get; set; } // Nullable as per DDL, has default in DB

    [Column("SortOrder")]
    public int? SortOrder { get; set; } // Nullable as per DDL, has default in DB

    // Navigation properties (optional but recommended for EF Core relationships)
    // Ensure Article and Media classes exist and have matching Guid properties.
    // [ForeignKey("ArticleGuid")]
    // public virtual ArticleDataModel? Article { get; set; } // Or whatever your Article entity is named

    // [ForeignKey("MediaGuid")]
    // public virtual Media? Media { get; set; }
}