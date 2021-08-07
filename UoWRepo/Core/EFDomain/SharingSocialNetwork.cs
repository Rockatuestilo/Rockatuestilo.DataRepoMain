using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [LinqToDB.Mapping.Table("SharingSocialNetwork")]
    public class SharingSocialNetworkLinqDB : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [LinqToDB.Mapping.Column("Id")]
        public int Id { get; set; }

        [LinqToDB.Mapping.Column("Nameofsocialnetwork")]
        public string Nameofsocialnetwork { get; set; }

        [LinqToDB.Mapping.Column("Createddate")]
        public DateTime Createddate { get; set; }

        [LinqToDB.Mapping.Column("Updateddate")]
        public DateTime UpdatedDate { get; set; }
    }
}
