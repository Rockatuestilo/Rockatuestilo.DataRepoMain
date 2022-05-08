namespace UoWRepo.Core.EFDomain;

public class UsersToRoles: TEntity, ITEntity
{
    public int User { get; set; }
        
    public int RoleGuid { get; set; }
}