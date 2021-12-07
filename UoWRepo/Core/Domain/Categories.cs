using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    [Table(Name = "news_categories")]
    public class Categories : TEntity,  ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "news_categoriesID"), NotNull]
        public int Id { get; set; }

        [Column(Name = "categoryOwner"), NotNull]
        public int CategoryOwner { get; set; }

        [Column(Name = "news_categoryName"), NotNull]
        public string CategoryName { get; set; }

        [Column(Name = "levelCategory"), NotNull]
        public int LevelCategory { get; set; }

        [Column(Name = "CreatedByID"), NotNull]
        public int CreatedbyId { get; set; }

        [Column(Name = "UpdatedByID"), NotNull]
        public int UpdatedbyId { get; set; }

        [Column(Name = "CreatedDate"), NotNull]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "updatedDate"), NotNull]
        public DateTime UpdatedDate { get; set; }       
    }

}
