using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain.UoWRepo.Core.EFDomain;

[Table("associations")]
public class Associations : TEntity, ITEntity
{
    [Column("associated_id")]
    public int AssociatedId { get; set; }

    [Column("associated_type")]
    public string AssociatedType { get; set; }

    [Column("object_id")]
    public int ObjectId { get; set; }

    [Column("object_type")]
    public string ObjectType { get; set; }
}