using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

[Table("Media")]
public class Media : BaseGuidTEntity, IBaseGuidTEntity
{
    [Required]
    [Column("FilePath")]
    public string FilePath { get; set; }

    [Required]
    [Column("MediaType")]
    public string MediaType { get; set; } // Enum values like 'Image', 'Video', etc.

    [Column("Author")]
    public string? Author { get; set; }

    [Column("License")]
    public string? License { get; set; }
}