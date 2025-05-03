using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.EFDomain;

[Table("Subjects")]

public class Subjects : TEntityGuid // Inherits Guid, CreatedDate, UpdatedDate
{
    // Inherited: Guid (PK), CreatedDate, UpdatedDate

    [Required]
    [StringLength(1024)] // Match DDL varchar length
    [Column("Name")]
    public string Name { get; set; } = null!;

    // REMOVE or COMMENT OUT the old 'Type' property:
    // [Required]
    // [Column("Type")]
    // public string Type { get; set; } // Enum values like 'Artist', 'Person', 'Object' <-- REMOVE THIS

    // ADD the correct property for the foreign key:
    [Required]
    [Column("SubjectTypeGuid")]
    [ForeignKey("SubjectType")] // Links to the navigation property below
    public Guid SubjectTypeGuid { get; set; } // Matches the DB column name and type

    [Column("Description", TypeName = "text")]
    public string? Description { get; set; }

    // --- Navigation Property ---
    // Optional but recommended: Navigation property to the related SubjectTypes entity
    public virtual SubjectTypes? SubjectType { get; set; }

    // Optional: Collection of SubjectMedia linking this Subject to Media
    // public virtual ICollection<SubjectMedia>? MediaLinks { get; set; }

    // Optional: Collections for relationships
    // public virtual ICollection<SubjectRelationships>? RelationshipsFrom { get; set; }
    // public virtual ICollection<SubjectRelationships>? RelationshipsTo { get; set; }
}