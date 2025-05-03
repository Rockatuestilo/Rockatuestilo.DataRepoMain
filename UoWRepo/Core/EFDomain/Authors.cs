using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("Authors")]
public class Authors : TEntityGuid // Inherits Guid PK and CreatedDate/UpdatedDate
{

    [Required]
    [StringLength(255)]
    [Column("FullName")]
    public string FullName { get; set; } = null!;

    [Column("Bio")] // TEXT maps to string, nullable
    public string? Bio { get; set; }

    [Required]
    [Column("Presentation")] // TEXT maps to string
    public string Presentation { get; set; } = null!;

    [StringLength(500)]
    [Column("Website")]
    public string? Website { get; set; }

    [Column("UserGuid")]
    [ForeignKey("User")] // Optional: Links to the User navigation property if defined
    public Guid? UserGuid { get; set; } // Nullable foreign key

    // --- Navigation Properties ---
    // Optional: Link back to the User if UserGuid is set
    public virtual Users? User { get; set; } // Assuming a 'Users' entity exists with a Guid PK

    // Optional: Collection of Media items this author created
    // public virtual ICollection<Media>? MediaItems { get; set; }
}