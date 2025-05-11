using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UoWRepo.Core.EFDomain;

[Table("Users")]
[Index(nameof(LoginName), IsUnique = true)]
[Index(nameof(Email), IsUnique = true)]
public class Users : TEntity, ITEntity
{
    

    [Required]
    [Column("Name")] public string Name { get; set; }

    [Required]
    [Column("LastName")] public string LastName { get; set; }

    [Required]
    [Column("LoginName")]
    
    public string LoginName { get; set; }

    [Required]
    [Column("Password")] public string Password { get; set; }

    [Column("LastLogin")] public DateTime LastLogin { get; set; }

    [Column("UserRoleLevel")] public int UserRoleLevel { get; set; }

    [Column("CreatedBy")] public int CreatedBy { get; set; }

    [Column("UpdatedBy")] public int UpdatedBy { get; set; }

    [Column("Email")] public string? Email { get; set; }
    // NOT NULL
    [Required]
    [Column("GUID")]
    public Guid Guid { get; set; }
    public bool VerifiedAccount { get; set; }
    
    /// <summary>
    /// Todos los Authors asociados a este User (cuando un autor coincide con un usuario de sistema).
    /// </summary>
    [InverseProperty(nameof(Authors.User))]
    public virtual ICollection<Authors>? AuthoredItems { get; set; }
    
    //public virtual ICollection<Authors> Authors { get; set; } = new List<Authors>();
    
    /// <summary>
    /// Tipos de subject que creó este usuario.
    /// </summary>
    [InverseProperty(nameof(SubjectTypes.CreatedByUser))]
    public virtual ICollection<SubjectTypes>? CreatedSubjectTypes { get; set; }

    /// <summary>
    /// Tipos de subject que actualizó por última vez este usuario.
    /// </summary>
    [InverseProperty(nameof(SubjectTypes.UpdatedByUser))]
    public virtual ICollection<SubjectTypes>? UpdatedSubjectTypes { get; set; }
    
}