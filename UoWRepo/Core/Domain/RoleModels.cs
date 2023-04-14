using System;
using LinqToDB.Mapping;
using ITEntity = UoWRepo.Core.BaseDomain.ITEntity;

namespace UoWRepo.Core.Domain;

[Table(Name = "Roles")]
public class RoleModels: Linq2DbEntity, ITEntity
{
    public string RoleName { get; set; }
    
    [Column(Name = "CreatedDate"), NotNull]
        
    public DateTime CreatedDate { get; set; } 
        
    public string RoleCode { get; set; }
    public string Description { get; set; }

    public bool Active { get; set; }
}