using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

[Table("SubjectRelationships")]
public class SubjectRelationships : BaseGuidTEntity, IBaseGuidTEntity
{
    [Required]
    [ForeignKey("FromSubject")]
    [Column("FromSubjectGuid")]
    public Guid FromSubjectGuid { get; set; }
    //public virtual Subjects FromSubject { get; set; }

    [Required]
    [ForeignKey("ToSubject")]
    [Column("ToSubjectGuid")]
    public Guid ToSubjectGuid { get; set; }
    //public virtual Subjects ToSubject { get; set; }

    [Required]
    [Column("RelationshipType")]
    public string RelationshipType { get; set; } // Enum-like values: "Related", "PartOf", "Member"
}