using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain;

public class TEntity : BaseTEntity
{
    [Range(0, int.MaxValue, ErrorMessage = "The value for ArticleId must be greater than -1.")]
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("Id")]
    public new int Id { get; set; }

    [Column("CreatedDate")] public new DateTime CreatedDate { get; set; } = DateTime.Now;

    [Column("UpdatedDate")] public new DateTime UpdatedDate { get; set; } = DateTime.Now;
}