using System;
using System.ComponentModel.DataAnnotations;

namespace UoWRepo.Core.EFDomain;

public class RoleModels: TEntity, ITEntity
{
    [Required]
    public string RoleName { get; set; }
        
    public DateTime CreatedDate { get; set; } 
        
    public string RoleCode { get; set; }
    
    public string Description { get; set; }

    public bool Active { get; set; }
}