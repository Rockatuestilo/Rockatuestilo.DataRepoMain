using LinqToDB.Mapping;
using System;

namespace UoWRepo.Core.Domain
{
    public class TEntity : UoWRepo.Core.BaseDomain.ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
