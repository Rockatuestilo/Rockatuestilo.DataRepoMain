using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

[Table("ContentMedia")]
public class ContentMedia : BaseGuidTEntity, IBaseGuidTEntity
{
    [Required]
    [Column("ContentGuid")]
    public Guid ContentGuid { get; set; } // Links to Articles or ContentItems

    [Required]
    [ForeignKey("Media")]
    [Column("MediaGuid")]
    public Guid MediaGuid { get; set; }
    public virtual Media Media { get; set; }

    [Column("Role")]
    public string? Role { get; set; } // Optional (e.g., "Featured Image", "Gallery Item")
}