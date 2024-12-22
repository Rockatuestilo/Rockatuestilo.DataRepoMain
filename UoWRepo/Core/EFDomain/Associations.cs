using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [Table("Associations")]
    public class Associations : TEntityGuid, ITEntityGuid
    {
        [Column("AssociatedGuid")]
        public Guid AssociatedGuid { get; set; }

        [ForeignKey("AssociatedType")]
        [Column("AssociatedTypeGuid")]
        public Guid AssociatedTypeGuid { get; set; }
        public virtual TypeAssociation AssociatedType { get; set; }

        [Column("ObjectGuid")]
        public Guid ObjectGuid { get; set; }

        [ForeignKey("ObjectType")]
        [Column("ObjectTypeGuid")]
        public Guid ObjectTypeGuid { get; set; }
        public virtual TypeAssociation ObjectType { get; set; }
        
        [Column("CreatedById")]
        public new int CreatedById { get; set; }

        [Column("UpdatedById")]
        public new int UpdatedById { get; set; }
    }
}


// Entity class for Media

// Entity class for ContentMedia