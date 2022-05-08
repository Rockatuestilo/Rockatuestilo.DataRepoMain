using System;

namespace UoWRepo.Core.BaseDomain;

public abstract class HashTagsBase: BaseTEntity, IHashTags
{
    public string HashtagWord { get; set; }
    public byte Allowed { get; set; }
    public int CreatedById { get; set; }
    public int UpdatedById { get; set; }
    public DateTime CreatedDate { get; set; }
}