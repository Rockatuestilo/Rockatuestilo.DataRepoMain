using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

[Table("SubjectMedia")]
public class SubjectMedia : BaseGuidTEntity, IBaseGuidTEntity
{
    [Required]
    [ForeignKey("Subject")]
    [Column("SubjectGuid")]
    public Guid SubjectGuid { get; set; }
    public virtual Subjects Subject { get; set; }

    [Required]
    [ForeignKey("Media")]
    [Column("MediaGuid")]
    public Guid MediaGuid { get; set; }
    public virtual Media Media { get; set; }

    [Column("IsFeatured")]
    public bool IsFeatured { get; set; } = false;
}