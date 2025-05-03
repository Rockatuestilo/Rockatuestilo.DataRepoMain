using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("HashtagsNews")]
public class HashTagsNews : TEntity, ITEntity
{
    [Column("NewsID")] public int NewsId { get; set; }

    [Column("HashtagID")] public int HashtagId { get; set; }

    [Column("CreatedByID")] public int CreatedById { get; set; }

    [Column("UpdatedByID")] public int UpdatedById { get; set; }
    
}