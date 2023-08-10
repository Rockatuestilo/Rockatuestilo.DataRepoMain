using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("news_categories")]
public class Categories : TEntity, ITEntity
{
    [Column("categoryOwner")] public int CategoryOwner { get; set; }

    [Column("news_categoryName")] public string CategoryName { get; set; }

    [Column("levelCategory")] public int LevelCategory { get; set; }

    [Column("CreatedByID")] public int CreatedById { get; set; }

    [Column("UpdatedByID")] public int UpdatedById { get; set; }

    [Column("CreatedDate")] public DateTime CreatedDate { get; set; }

    [Column("updatedDate")] public new DateTime UpdatedDate { get; set; }
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("news_categoriesID")]
    public new int Id { get; set; }
}