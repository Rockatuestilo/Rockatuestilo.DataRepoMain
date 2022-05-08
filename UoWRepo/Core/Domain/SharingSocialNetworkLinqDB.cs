using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "SharingSocialNetwork")]
    public class SharingSocialNetworkLinqDB : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "Nameofsocialnetwork"), NotNull]
        public string Nameofsocialnetwork { get; set; }

        [Column(Name = "Createddate"), NotNull]
        public DateTime Createddate { get; set; }

        [Column(Name = "Updateddate"), NotNull]
        public DateTime UpdatedDate { get; set; }
    }
}
