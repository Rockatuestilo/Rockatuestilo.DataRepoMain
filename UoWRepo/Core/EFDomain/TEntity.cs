using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    public class TEntity 
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [LinqToDB.Mapping.Column("Id")]
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
