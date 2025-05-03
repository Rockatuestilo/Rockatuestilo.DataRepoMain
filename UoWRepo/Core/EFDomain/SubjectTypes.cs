using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain;

[Table("SubjectTypes")]
[Index(nameof(Code), IsUnique = true)] // Defines the unique constraint on Code
public class SubjectTypes : TEntityGuid // Inherits Guid PK and CreatedDate/UpdatedDate
{

    [Required]
    [StringLength(50)]
    [Column("Code")]
    public string Code { get; set; } = null!;

    [Column("Description", TypeName = "text")] // Explicitly mapping for TEXT
    public string? Description { get; set; }

    [Column("CreatedByGuid")]
    // Optionally add ForeignKey attribute if you have a navigation property to Users using GUIDs
    // [ForeignKey("CreatedByUser")]
    public Guid? CreatedByGuid { get; set; } // Nullable

    [Column("UpdatedByGuid")]
    // Optionally add ForeignKey attribute if you have a navigation property to Users using GUIDs
    // [ForeignKey("UpdatedByUser")]
    public Guid? UpdatedByGuid { get; set; } // Nullable

    // --- Navigation Properties (Optional) ---
    // Assuming you have a Users entity with a Guid PK
    // public virtual Users? CreatedByUser { get; set; }
    // public virtual Users? UpdatedByUser { get; set; }

    // Optional: Collection of Subjects of this type
    // public virtual ICollection<Subjects>? Subjects { get; set; }
}