﻿using System;
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
        public new int Id { get; set; }

        [Column("newsOwner")]
        public int UserIdOwner { get; set; }

        [Column("newsTittel"),]
        public string NewsTitle { get; set; }

        [Column("newsContent"),]
        public string NewsContent { get; set; }

        [Column("newsCreatedDate")]
        public DateTime NewsCreatedDate { get; set; }

        [Column("newsLastUpdateDate")]
        public new DateTime UpdatedDate { get; set; }

        [Column("newsPermission"),]
        public int NewsPermission { get; set; }

        [Column("newsChangedByID"),]
        public int NewsChangedById { get; set; }

        [Column("category_id"),]
        public int CategoryId { get; set; }

        [Column("publicationType"),]
        public int PublicationType { get; set; } = 0;

        [Column("galleryID"),]
        public int GalleryId { get; set; }

        [Column("newsPresentation"),]
        public string NewsPresentation { get; set; }

        [Column("publicationdate")]
        public DateTime PublicationDate { get; set; }

        [Column("titleforURL"),]
        public string TitleForUrl { get; set; }

        [Column("HashtagsNewsId"),]
        public int? HashtagsNewsId { get; set; }
        
        [Column("ArticleVersion")]
        public int? ArticleVersion { get; set; }

    }
}
