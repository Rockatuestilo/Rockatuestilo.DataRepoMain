using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "NewsPublicationType")]
    public class NewsPublicationType : Linq2DbEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "NewsPublicationTypeID"), NotNull]
        public new int Id { get; set; }

        [Column(Name = "TypeOfPublication"), NotNull]
        public string TypeOfPublication { get; set; } = null!;

        [Column(Name = "LevelUser"), NotNull]
        public int LevelUser { get; set; }

        [Column(Name = "CreatedByID"), NotNull]
        public int CreatedById { get; set; }

        [Column(Name = "UpdatedByID"), NotNull]
        public int UpdatedById { get; set; }

        [Column(Name = "CreatedDate"), NotNull]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "updatedDate"), NotNull]
        public new DateTime UpdatedDate { get; set; }
    }
}
