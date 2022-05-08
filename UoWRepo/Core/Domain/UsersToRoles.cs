using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain;

[Table(Name = "UsersToRoles")]
public class UsersToRoles: TEntity, ITEntity
{
    public int User { get; set; }
        
    public int RoleGuid { get; set; }
}