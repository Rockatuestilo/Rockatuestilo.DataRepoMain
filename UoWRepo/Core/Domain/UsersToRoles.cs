using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain;

[Table(Name = "UsersToRoles")]
public class UsersToRoles: Linq2DbEntity, ITEntity
{
    public int User { get; set; }
        
    public int RoleGuid { get; set; }
}