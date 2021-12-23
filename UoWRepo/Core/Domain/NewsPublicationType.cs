using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "NewsPublicationType")]
    public class NewsPublicationType : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "NewsPublicationTypeID"), NotNull]
        public int Id { get; set; }

        [Column(Name = "TypeOfPublication"), NotNull]
        public string Typeofpublication { get; set; }

        [Column(Name = "LevelUser"), NotNull]
        public int Leveluser { get; set; }

        [Column(Name = "CreatedByID"), NotNull]
        public int Createdbyid { get; set; }

        [Column(Name = "UpdatedByID"), NotNull]
        public int Updatedbyid { get; set; }

        [Column(Name = "CreatedDate"), NotNull]
        public DateTime Createddate { get; set; }

        [Column(Name = "updatedDate"), NotNull]
        public DateTime UpdatedDate { get; set; }
    }
}
