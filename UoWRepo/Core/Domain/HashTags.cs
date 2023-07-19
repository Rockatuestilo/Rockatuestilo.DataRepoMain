using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain;

[Table(Name = "Hashtags")]
public class HashTags : Linq2DbEntity, IHashTags
{
    [PrimaryKey]
    [Identity]
    [Column(Name = "Id")]
    [NotNull]
    public new int Id { get; set; }

    [Column(Name = "HashtagWord")]
    [NotNull]
    public string HashtagWord { get; set; }

    [Column(Name = "Allowed")] [NotNull] public byte Allowed { get; set; }

    [Column(Name = "CreatedByID")]
    [NotNull]
    public int CreatedById { get; set; }

    [Column(Name = "UpdatedByID")]
    [NotNull]
    public int UpdatedById { get; set; }


    [Column(Name = "updatedDate")]
    [NotNull]
    public new DateTime UpdatedDate { get; set; }
}