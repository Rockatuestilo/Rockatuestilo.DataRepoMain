using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("Types")]
public class TypeAssociation
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("TypeId")]
    public int TypeId { get; set; }

    [Column("TypeName")]
    public string TypeName { get; set; }
}