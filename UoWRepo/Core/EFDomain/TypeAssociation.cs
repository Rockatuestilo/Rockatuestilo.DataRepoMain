using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("Types")]
public class TypeAssociation: TEntityGuid, ITEntityGuid
{


    [Column("TypeName")]
    public string TypeName { get; set; }
}