using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("Authors")]
// Inherits: Guid (PK), CreatedDate, UpdatedDate
public class Authors : TEntityGuid
{
    [Required]
    [StringLength(255)]
    [Column("FullName")]
    public string FullName { get; set; } = null!;

    [Column("Bio", TypeName = "text")]
    public string? Bio { get; set; }

    [Required]
    [Column("Presentation", TypeName = "text")]
    public string Presentation { get; set; } = null!;

    [StringLength(500)]
    [Column("Website")]
    public string? Website { get; set; }

    /// <summary>
    /// Optional FK to a Users record (if the author is also a system user)
    /// </summary>
    [Column("UserGuid")]
    public Guid? UserGuid { get; set; }

    /*[ForeignKey(nameof(UserGuid))]
    [InverseProperty(nameof(Users.AuthoredItems))]
    public virtual Users? User { get; set; }*/

    /*/// <summary>
    /// Collection of Media items this author created
    /// </summary>
    [InverseProperty(nameof(Media.Author))]
    public virtual ICollection<Media>? MediaItems { get; set; }*/
}