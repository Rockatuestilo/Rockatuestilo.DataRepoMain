using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;

[Table("SubjectMedia")]
public class SubjectMedia : TEntityGuid // Inherits Guid, CreatedDate, UpdatedDate
{
    // Inherited: Guid (PK), CreatedDate, UpdatedDate

    [Required]
    [ForeignKey("Subject")]
    [Column("SubjectGuid")]
    public Guid SubjectGuid { get; set; }
    public virtual Subjects? Subject { get; set; } // Corrected Navigation Property

    [Required]
    [ForeignKey("Media")]
    [Column("MediaGuid")]
    public Guid MediaGuid { get; set; }
    public virtual Media? Media { get; set; } // Corrected Navigation Property

    [Column("IsFeatured")]
    public bool IsFeatured { get; set; } = false;

    // --- ADD THESE MISSING PROPERTIES ---
    [Column("CreatedByGuid")]
    // Optional: Add [ForeignKey("CreatedByUser")] if defining that navigation property
    public Guid? CreatedByGuid { get; set; } // Nullable Guid

    [Column("UpdatedByGuid")]
    // Optional: Add [ForeignKey("UpdatedByUser")] if defining that navigation property
    public Guid? UpdatedByGuid { get; set; } // Nullable Guid

    // --- Optional Navigation Properties for User Guids ---
    // public virtual Users? CreatedByUser { get; set; } // Assuming Users has Guid PK
    // public virtual Users? UpdatedByUser { get; set; }
}