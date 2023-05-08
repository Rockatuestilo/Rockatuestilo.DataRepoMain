using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [Table("SharingSocialNetwork")]
    public class SharingSocialNetworkLinqDB : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [LinqToDB.Mapping.Column("Id")]
        public new int Id { get; set; }

        [LinqToDB.Mapping.Column("Nameofsocialnetwork")]
        public string Nameofsocialnetwork { get; set; }

        [LinqToDB.Mapping.Column("Createddate")]
        public DateTime CreatedDate { get; set; }

        [LinqToDB.Mapping.Column("Updateddate")]
        public new DateTime UpdatedDate { get; set; }
    }
}
