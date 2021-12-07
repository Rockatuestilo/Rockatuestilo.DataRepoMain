using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    [Table(Name = "tb_news")]
    public class NewsEtty : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "newsID"), NotNull]
        public int Id { get; set; }

        [Column(Name = "newsOwner"), NotNull]
        public int UserIdOwner { get; set; }

        [Column(Name = "newsTittel"), Nullable]
        public string Newstittel { get; set; }

        [Column(Name = "newsContent"), Nullable]
        public string Newscontent { get; set; }

        [Column(Name = "newsCreatedDate"), NotNull]
        public DateTime Newscreateddate { get; set; }

        [Column(Name = "newsLastUpdateDate"), NotNull]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "newsPermission"), Nullable]
        public int Newspermission { get; set; }

        [Column(Name = "newsChangedByID"), Nullable]
        public int Newschangedbyid { get; set; }

        [Column(Name = "category_id"), Nullable]
        public int CategoryId { get; set; }

        [Column(Name = "publicationType"), Nullable]
        public int Publicationtype { get; set; } = 0;

        [Column(Name = "galleryID"), Nullable]
        public int Galleryid { get; set; }

        [Column(Name = "newsPresentation"), Nullable]
        public string Newspresentation { get; set; }

        [Column(Name = "publicationdate"), NotNull]
        public DateTime Publicationdate { get; set; }

        [Column(Name = "titleforURL"), Nullable]
        public string Titleforurl { get; set; }

        [Column(Name = "HashtagsNewsId"), Nullable]
        public int HashtagsNewsId { get; set; }

    }
}
