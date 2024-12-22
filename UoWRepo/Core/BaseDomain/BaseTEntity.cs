using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.BaseDomain;

public abstract class BaseTEntity : IBaseTEntity
{
    public virtual int Id { get; set; }
    
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
}

public abstract class BaseGuidTEntity : IBaseGuidTEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Column("Guid")]
    public virtual Guid Guid { get; set; }
    
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
}