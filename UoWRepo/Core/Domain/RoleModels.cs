using System;
using LinqToDB.Mapping;
using ITEntity = UoWRepo.Core.BaseDomain.ITEntity;

namespace UoWRepo.Core.Domain;

[Table(Name = "Roles")]
public class RoleModels: Linq2DbEntity, ITEntity
{

    [Column(Name = "RoleName"), NotNull]
    public string RoleName { get; set; } = null!;

    [Column(Name = "CreatedDate"), NotNull]
        
    public DateTime CreatedDate { get; set; } 
        
    [Column(Name = "RoleCode"), NotNull]
    public string RoleCode { get; set; }
    
    [Column(Name = "Description"), NotNull]
    public string Description { get; set; }
    
    [Column(Name = "Active"), NotNull]
    public bool Active { get; set; }
}