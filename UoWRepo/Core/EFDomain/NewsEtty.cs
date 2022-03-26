using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UoWRepo.Core.EFDomain
{
    [Table("tb_news")]
    public class NewsEtty : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("newsID")]
        public int Id { get; set; }

        [Column("newsOwner")]
        public int UserIdOwner { get; set; }

        [Column("newsTittel"),]
        public string Newstittel { get; set; }

        [Column("newsContent"),]
        public string Newscontent { get; set; }

        [Column("newsCreatedDate")]
        public DateTime Newscreateddate { get; set; }

        [Column("newsLastUpdateDate")]
        public DateTime UpdatedDate { get; set; }

        [Column("newsPermission"),]
        public int Newspermission { get; set; }

        [Column("newsChangedByID"),]
        public int Newschangedbyid { get; set; }

        [Column("category_id"),]
        public int CategoryId { get; set; }

        [Column("publicationType"),]
        public int Publicationtype { get; set; } = 0;

        [Column("galleryID"),]
        public int Galleryid { get; set; }

        [Column("newsPresentation"),]
        public string Newspresentation { get; set; }

        [Column("publicationdate")]
        public DateTime Publicationdate { get; set; }

        [Column("titleforURL"),]
        public string Titleforurl { get; set; }

        [Column("HashtagsNewsId"),]
        public int? HashtagsNewsId { get; set; }
        
        [Column("ArticleVersion")]
        public string? ArticleVersion { get; set; }

    }
}
