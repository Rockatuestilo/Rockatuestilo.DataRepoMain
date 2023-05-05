using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "news_categories")]
    public class Categories : Linq2DbEntity,  ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "news_categoriesID"), NotNull]
        public new int Id { get; set; }

        [Column(Name = "categoryOwner"), NotNull]
        public int CategoryOwner { get; set; }

        [Column(Name = "news_categoryName"), NotNull]
        public string CategoryName { get; set; } = null!;

        [Column(Name = "levelCategory"), NotNull]
        public int LevelCategory { get; set; }

        [Column(Name = "CreatedByID"), NotNull]
        public int CreatedById { get; set; }

        [Column(Name = "UpdatedByID"), NotNull]
        public int UpdatedById { get; set; }

        [Column(Name = "updatedDate"), NotNull]
        public new DateTime UpdatedDate { get; set; }       
    }

}
