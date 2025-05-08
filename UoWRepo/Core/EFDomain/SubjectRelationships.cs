using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;

[Table("SubjectRelationships")]
public class SubjectRelationships : TEntityGuid // Hereda Guid PK, CreatedDate, UpdatedDate
{
    // FK al subject de origen
    [Required]
    [Column("FromSubjectGuid")]
    public Guid FromSubjectGuid { get; set; }

    [ForeignKey(nameof(FromSubjectGuid))]
    [InverseProperty(nameof(Subjects.RelationshipsFrom))]
    public virtual Subjects FromSubject { get; set; } = null!;

    // FK al subject de destino
    [Required]
    [Column("ToSubjectGuid")]
    public Guid ToSubjectGuid { get; set; }

    [ForeignKey(nameof(ToSubjectGuid))]
    [InverseProperty(nameof(Subjects.RelationshipsTo))]
    public virtual Subjects ToSubject { get; set; } = null!;

    // Si tienes más campos, p. ej. tipo de relación o sort order:
    [StringLength(50)]
    [Column("RelationshipType")]
    public string? RelationshipType { get; set; }

    [Column("SortOrder")]
    public int? SortOrder { get; set; }
}