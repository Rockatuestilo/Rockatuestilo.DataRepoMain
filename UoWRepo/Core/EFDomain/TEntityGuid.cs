using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain;

public class TEntityGuid : BaseGuidTEntity
{
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Guid")]
    public new Guid Guid { get; set; }

    [Column("CreatedDate")] public new DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column("UpdatedDate")] public new DateTime UpdatedDate { get; set; } = DateTime.Now;
}