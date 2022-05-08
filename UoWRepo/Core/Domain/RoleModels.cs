using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain;

[Table(Name = "RoleModels")]
public class RoleModels: TEntityGuid, ITEntityGuid
{
    public Guid Guid { get; set; }
        
    public string RoleName { get; set; }
        
    public DateTime CreatedDate { get; set; }
        
    public string RoleCode { get; set; }
    public string Description { get; set; }

    public bool Active { get; set; }
}