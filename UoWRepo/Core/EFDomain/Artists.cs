using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("Artists")]
public class Artists: TEntityGuid // No standard base class inheritance due to specific PK name and audit columns
{

    [Required]
    [StringLength(255)]
    [Column("ArtistName")]
    public string ArtistName { get; set; } = null!; // Initialize required string
    

    [Required]
    [Column("InsertedByUserID")]
    public int InsertedByUserID { get; set; }

    [Required]
    [Column("UpdatedByUserID")]
    public int UpdatedByUserID { get; set; }

    // Optional: Navigation property if Artists links to other tables (e.g., ArtistPreviewImage)
    // public virtual ICollection<ArtistPreviewImage>? ArtistPreviewImages { get; set; }
}