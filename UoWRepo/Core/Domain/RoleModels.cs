using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain;

[Table(Name = "RoleModels")]
public class RoleModels: TEntity, ITEntity
{
    public string RoleName { get; set; }
    
    [Column(Name = "CreatedDate"), NotNull]
        
    public DateTime CreatedDate { get; set; } 
        
    public string RoleCode { get; set; }
    public string Description { get; set; }

    public bool Active { get; set; }
}