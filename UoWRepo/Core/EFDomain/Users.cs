using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("Users")]
public class Users : TEntity, ITEntity
{
    [Column("Name")] public string Name { get; set; }

    [Column("LastName")] public string LastName { get; set; }

    [Column("LoginName")] public string LoginName { get; set; }

    [Column("Password")] public string Password { get; set; }

    [Column("LastLogin")] public DateTime LastLogin { get; set; }

    [Column("UserRoleLevel")] public int UserRoleLevel { get; set; }

    [Column("CreatedBy")] public int CreatedBy { get; set; }

    [Column("UpdatedBy")] public int UpdatedBy { get; set; }

    [Column("Email")] public string Email { get; set; }


    public bool VerifiedAccount { get; set; }
}