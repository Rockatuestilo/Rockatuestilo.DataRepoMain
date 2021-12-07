using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    [Table(Name = "HashtagsNews")]
    public class HashTagsNews : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "NewsID"), NotNull]
        public int NewsId { get; set; }

        [Column(Name = "HashtagID"), NotNull]
        public int HashtagId { get; set; }

        [Column(Name = "CreatedByID"), Nullable]
        public int CreatedById { get; set; }

        [Column(Name = "UpdatedByID"), Nullable]
        public int UpdatedById { get; set; }

        [Column(Name = "CreatedDate"), Nullable]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "updatedDate"), Nullable]
        public DateTime UpdatedDate { get; set; }

        public static explicit operator HashTagsNews(int v)
        {
            throw new NotImplementedException();
        }
    }
}



