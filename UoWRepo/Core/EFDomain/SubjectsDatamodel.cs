using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.EFDomain;

[Table("Subjects")]
public class SubjectsDataModel : TEntityGuid  // Hereda: Guid PK, CreatedDate, UpdatedDate
{
    [Required]
    [StringLength(1024)]
    [Column("Name")]
    public string Name { get; set; } = null!;

    // FK al lookup de tipo
    [Required]
    [Column("SubjectTypeGuid")]
    public Guid SubjectTypeGuid { get; set; }

    [Column("Description", TypeName = "text")]
    public string? Description { get; set; }
    
    [Column("CreatedByGuid")]
    public Guid? CreatedByGuid { get; set; }

    /*[ForeignKey(nameof(CreatedByGuid))]
    [InverseProperty(nameof(Users.CreatedSubjectTypes))]
    public virtual Users? CreatedByUser { get; set; }*/

    [Column("UpdatedByGuid")]
    public Guid? UpdatedByGuid { get; set; }

    // Navegación al lookup
    /*[ForeignKey(nameof(SubjectTypeGuid))]
    [InverseProperty(nameof(SubjectTypes.RelatedSubjects))]
    public virtual SubjectTypes SubjectType { get; set; }*/
    
    // Medios asociados
    /*[InverseProperty(nameof(SubjectMedia.Subject))]
    public virtual ICollection<SubjectMedia>? SubjectMediaItems { get; set; }

    // Relaciones “desde”
    [InverseProperty(nameof(SubjectRelationships.FromSubjectDatamodel))]
    public virtual ICollection<SubjectRelationships>? RelationshipsFrom { get; set; }

    // Relaciones “hacia”
    [InverseProperty(nameof(SubjectRelationships.ToSubjectDatamodel))]
    public virtual ICollection<SubjectRelationships>? RelationshipsTo { get; set; }*/
}