using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [LinqToDB.Mapping.Table("SharedObject")]
    public class SharedObjectLinqDB : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [LinqToDB.Mapping.Column("Id")]
        public int Id { get; set; }

        [LinqToDB.Mapping.Column("Sharingsocialnetworkid")]
        public int Sharingsocialnetworkid { get; set; }

        [LinqToDB.Mapping.Column("Note")]
        public string Note { get; set; }

        [LinqToDB.Mapping.Column("Createddate")]
        public DateTime Createddate { get; set; }

        [LinqToDB.Mapping.Column("Updateddate")]
        public DateTime UpdatedDate { get; set; }

        [LinqToDB.Mapping.Column("IdOfSharedelement")]
        public int IdOfSharedelement { get; set; }

        [LinqToDB.Mapping.Column("Typeid")]
        public int Typeid { get; set; }
    }
}
