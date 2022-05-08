using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain;

[Table(Name = "UsersToRoles")]
public class UsersToRoles: TEntityGuid, ITEntityGuid
{
    public Guid Guid { get; set; }
        
    public int User { get; set; }
        
    public Guid RoleGuid { get; set; }
}