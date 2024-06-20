using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.LinqDomain;

[Table(Name = "HashtagsNews")]
public class HashTagsNews : Linq2DbEntity, ITEntity
{
    [Column(Name = "NewsID")] [NotNull] public int NewsId { get; set; }

    [Column(Name = "HashtagID")] [NotNull] public int HashtagId { get; set; }

    [Column(Name = "CreatedByID")]
    [Nullable]
    public int CreatedById { get; set; }

    [Column(Name = "UpdatedByID")]
    [Nullable]
    public int UpdatedById { get; set; }

    [PrimaryKey]
    [Identity]
    [Column(Name = "Id")]
    [NotNull]
    public new int Id { get; set; }

    [Column(Name = "updatedDate")]
    [Nullable]
    public new DateTime UpdatedDate { get; set; }

    public static explicit operator HashTagsNews(int v)
    {
        throw new NotImplementedException();
    }
}