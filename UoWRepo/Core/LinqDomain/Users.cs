using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain;

[Table(Name = "Users")]
public class Users : Linq2DbEntity, ITEntity
{
    [Column(Name = "Name")] 
    [NotNull] 
    public string Name { get; set; } = null!;

    [Column(Name = "LastName")] 
    [NotNull] 
    public string LastName { get; set; } = null!;

    [Column(Name = "LoginName")]
    [NotNull] 
    public string LoginName { get; set; } = null!;

    [Column(Name = "Password")] 
    [NotNull] 
    public string Password { get; set; } = null!;

    [Column(Name = "LastLogin")] 
    [NotNull] 
    public DateTime LastLogin { get; set; }

    [Column(Name = "UserRoleLevel")]
    [NotNull]
    public int UserRoleLevel { get; set; }

    [Column(Name = "CreatedBy")] 
    [NotNull] public int CreatedBy { get; set; }

    [Column(Name = "UpdatedBy")] 
    [NotNull] 
    public int UpdatedBy { get; set; }

    [Column(Name = "Email")] 
    [Nullable] 
    public string? Email { get; set; }

    [Column(Name = "VerifiedAccount")]
    [Nullable]
    public bool VerifiedAccount { get; set; }

    [PrimaryKey]
    [Identity]
    [Column(Name = "Id")]
    [NotNull]
    public new int Id { get; set; }
}