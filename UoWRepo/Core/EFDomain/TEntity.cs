using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.EFDomain
{
    public class TEntity : BaseTEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [LinqToDB.Mapping.Column("Id")]
        public int Id { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}
