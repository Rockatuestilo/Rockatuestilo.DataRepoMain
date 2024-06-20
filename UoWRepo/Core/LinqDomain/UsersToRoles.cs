using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain;

[Table(Name = "UsersToRoles")]
public class UsersToRoles : Linq2DbEntity, ITEntity
{
    [Column(Name = "User")] [NotNull] public int User { get; set; }

    [Column(Name = "RoleGuid")] [NotNull] public int RoleGuid { get; set; }

    [Column(Name = "CreatedDate")]
    [NotNull]
    public DateTime CreatedDate { get; set; }
}