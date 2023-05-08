using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "SharingSocialNetwork")]
    public class SharingSocialNetworkLinqDB : Linq2DbEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public new int Id { get; set; }

        [Column(Name = "Nameofsocialnetwork"), NotNull]
        public string NameOfSocialnetwork { get; set; }

        [Column(Name = "Createddate"), NotNull]
        public DateTime CreatedDate { get; set; }

        [Column(Name = "Updateddate"), NotNull]
        public new DateTime UpdatedDate { get; set; }
    }
}
