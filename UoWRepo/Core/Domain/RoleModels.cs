using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain;

[Table(Name = "Roles")]
public class RoleModels: TEntity, ITEntity
{
    public string RoleName { get; set; }
        
    public DateTime CreatedDate { get; set; } 
        
    public string RoleCode { get; set; }
    public string Description { get; set; }

    public bool Active { get; set; }
}