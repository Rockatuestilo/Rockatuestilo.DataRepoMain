using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain; 

[Table("ArticleMedia")]
// Hereda Guid PK, CreatedDate, UpdatedDate; la clave compuesta se configurará vía Fluent API si lo deseas
public class ArticleMedia : TEntityGuid
{
    // Scalar FK a Article
    [Required]
    [Column("ArticleGuid")]
    public Guid ArticleGuid { get; set; }

    // Scalar FK a Media
    [Required]
    [Column("MediaGuid")]
    public Guid MediaGuid { get; set; }

    // Rol del medio en el artículo
    [StringLength(50)]
    [Column("MediaRole")]
    public string? MediaRole { get; set; }   // nullable con default en BD

    // Orden de aparición
    [Column("SortOrder")]
    public int? SortOrder { get; set; }      // nullable con default en BD

    // --- Propiedades de navegación ---

    /// <summary>
    /// El artículo al que pertenece este medio.
    /// Asegúrate de que ArticleDataModel (o tu clase Articles) tenga:
    /// [InverseProperty(nameof(ArticleMedia.Article))]
    /// public virtual ICollection<ArticleMedia>? ArticleMediaItems { get; set; }
    /// </summary>
    /*[ForeignKey(nameof(ArticleGuid))]
    [InverseProperty(nameof(ArticleDataModel.ArticleMediaItems))]
    public virtual ArticleDataModel? Article { get; set; }*/

    /// <summary>
    /// El medio que se asocia al artículo.
    /// Asegúrate de que Media tenga:
    /// [InverseProperty(nameof(ArticleMedia.Media))]
    /// public virtual ICollection<ArticleMedia>? ArticleMediaItems { get; set; }
    /// </summary>
    /*[ForeignKey(nameof(MediaGuid))]
    [InverseProperty(nameof(Media.ArticleMediaItems))]
    public virtual Media? Media { get; set; }*/
    
}