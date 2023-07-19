using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace UoWRepo.Core.EFDomain;

[Table("Roles")]
[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Code), IsUnique = true)]
public class RoleModels : TEntity, ITEntity
{
    // needs to be unique
    [Required] public string Name { get; set; }

    public string Code { get; set; }

    public string Description { get; set; }

    public bool Active { get; set; }
}