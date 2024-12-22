using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

[Table("Subjects")]

public class Subjects : BaseGuidTEntity, IBaseGuidTEntity
{
    [Required]
    [Column("Name")]
    public string Name { get; set; }

    [Required]
    [Column("Type")]
    public string Type { get; set; } // Enum values like 'Artist', 'Person', 'Object'

    [Column("Description")]
    public string? Description { get; set; }
}