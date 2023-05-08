using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "galleries")]
    public class Galleries : Linq2DbEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "galleryID"), NotNull]
        public new int Id { get; set; }

        [Column(Name = "galleryOwner"), Nullable]
        public int GalleryOwner { get; set; }

        [Column(Name = "galleryName"), Nullable]
        public string? GalleryName { get; set; }

        [Column(Name = "galleryPath"), NotNull]
        public string GalleryPath { get; set; } = null!;

        [Column(Name = "CreatedByID"), Nullable]
        public int? CreatedById { get; set; }

        [Column(Name = "UpdatedByID"), Nullable]
        public int? UpdatedById { get; set; }

        [Column(Name = "CreatedDate"), Nullable]
        public DateTime? CreatedDate { get; set; }

        [Column(Name = "updatedDate"), Nullable]
        public new DateTime? UpdatedDate { get; set; }

        [Column(Name = "categorylevel"), Nullable]
        public int? CategoryLevel { get; set; }

        [Column(Name = "publishtype"), Nullable]
        public int? PublishType { get; set; }
    }
}
