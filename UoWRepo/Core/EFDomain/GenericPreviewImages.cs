using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("GenericPreviewImages")]
public class GenericPreviewImages : TEntity // Inherits Id, CreatedDate, UpdatedDate
{
    [Required]
    [Column(TypeName = "longtext")] // Explicitly mapping for LONGTEXT
    public string Base64String { get; set; } = null!;


    [Required]
    [Column("InsertedByUserID")]
    // Optionally add ForeignKey attribute if you have a navigation property
    // [ForeignKey("InsertedByUser")]
    public int CreatedById { get; set; } // Map InsertedByUserID to CreatedById for consistency

    [Required]
    [Column("UpdatedByUserID")]
    // Optionally add ForeignKey attribute if you have a navigation property
    // [ForeignKey("UpdatedByUser")]
    public int UpdatedById { get; set; } // Map UpdatedByUserID to UpdatedById for consistency

    [Required]
    [Column("MaxSize")]
    public int MaxSize { get; set; }

    [StringLength(255)]
    [Column("PathToImage")]
    public string? PathToImage { get; set; } // Nullable

    // --- Navigation Properties (Optional) ---
    // Assuming you have a Users entity with an int Id PK
    // public virtual Users? InsertedByUser { get; set; }
    // public virtual Users? UpdatedByUser { get; set; }

    // Optional: Navigation property if GenericPreviewImages links back (e.g., to ArtistPreviewImage)
    // public virtual ICollection<ArtistPreviewImage>? ArtistPreviewImages { get; set; }
}