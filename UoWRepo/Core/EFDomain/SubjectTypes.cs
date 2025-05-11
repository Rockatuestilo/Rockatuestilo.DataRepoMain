using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain;

[Table("SubjectTypes")]
[Index(nameof(Code), IsUnique = true)]
public class SubjectTypes : TEntityGuid  // Hereda: Guid PK, CreatedDate, UpdatedDate
{
    [Required]
    [StringLength(50)]
    [Column("Code")]
    public string Code { get; set; } = null!;

    [Column("Description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("CreatedByGuid")]
    public Guid? CreatedByGuid { get; set; }

    /*[ForeignKey(nameof(CreatedByGuid))]
    [InverseProperty(nameof(Users.CreatedSubjectTypes))]
    public virtual Users? CreatedByUser { get; set; }*/

    [Column("UpdatedByGuid")]
    public Guid? UpdatedByGuid { get; set; }

    /*[ForeignKey(nameof(UpdatedByGuid))]
    [InverseProperty(nameof(Users.UpdatedSubjectTypes))]
    public virtual Users? UpdatedByUser { get; set; }*/

    // Inversa a SubjectsDatamodel.SubjectType
    /*[InverseProperty(nameof(SubjectsDatamodel.SubjectType))]
    public virtual ICollection<SubjectsDatamodel>? RelatedSubjects { get; set; }*/
}