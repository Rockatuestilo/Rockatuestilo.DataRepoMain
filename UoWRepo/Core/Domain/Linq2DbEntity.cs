using LinqToDB.Mapping;
using System;

namespace UoWRepo.Core.Domain
{
    public class Linq2DbEntity : BaseDomain.BaseTEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
