using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("UsersToRoles")]

public class UsersToRoles : TEntity, ITEntity
{
    public int User { get; set; }

    public int RoleGuid { get; set; }
}