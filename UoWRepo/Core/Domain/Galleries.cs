using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    [Table(Name = "galleries")]
    public class Galleries : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "galleryID"), NotNull]
        public int Id { get; set; }

        [Column(Name = "galleryOwner"), Nullable]
        public int Galleryowner { get; set; }

        [Column(Name = "galleryName"), Nullable]
        public string Galleryname { get; set; }

        [Column(Name = "galleryPath"), NotNull]
        public string Gallerypath { get; set; }

        [Column(Name = "CreatedByID"), Nullable]
        public int Createdbyid { get; set; }

        [Column(Name = "UpdatedByID"), Nullable]
        public int Updatedbyid { get; set; }

        [Column(Name = "CreatedDate"), Nullable]
        public DateTime Createddate { get; set; }

        [Column(Name = "updatedDate"), Nullable]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "categorylevel"), Nullable]
        public int Categorylevel { get; set; }

        [Column(Name = "publishtype"), Nullable]
        public int Publishtype { get; set; }
    }
}
