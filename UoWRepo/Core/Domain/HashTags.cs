using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    [Table(Name = "Hashtags")]
    public class HashTags : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "HashtagWord"), NotNull]
        public string HashtagWord { get; set; }

        [Column(Name = "Allowed"), NotNull]
        public byte Allowed { get; set; }

        [Column(Name = "CreatedByID"), NotNull]
        public int CreatedById { get; set; }

        [Column(Name = "UpdatedByID"), NotNull]
        public int UpdatedById { get; set; }

        [Column(Name = "CreatedDate"), NotNull]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "updatedDate"), NotNull]
        public DateTime UpdatedDate { get; set; }
    }
}


