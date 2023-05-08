using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [Table("SharedObject")]
    public class SharedObjectLinqDB : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [LinqToDB.Mapping.Column("Id")]
        public new int Id { get; set; }

        [LinqToDB.Mapping.Column("Sharingsocialnetworkid")]
        public int Sharingsocialnetworkid { get; set; }

        [LinqToDB.Mapping.Column("Note")]
        public string Note { get; set; }

        [LinqToDB.Mapping.Column("Createddate")]
        public DateTime CreatedDate { get; set; }

        [LinqToDB.Mapping.Column("Updateddate")]
        public new DateTime UpdatedDate { get; set; }

        [LinqToDB.Mapping.Column("IdOfSharedelement")]
        public int IdOfSharedelement { get; set; }

        [LinqToDB.Mapping.Column("Typeid")]
        public int Typeid { get; set; }
    }
}
