using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    
    [Table(Name = "SharedObject")]
    public class SharedObjectLinqDB : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "Id"), NotNull]
        public int Id { get; set; }

        [Column(Name = "Sharingsocialnetworkid"), NotNull]
        public int Sharingsocialnetworkid { get; set; }

        [Column(Name = "Note"), NotNull]
        public string Note { get; set; }

        [Column(Name = "Createddate"), NotNull]
        public DateTime Createddate { get; set; }

        [Column(Name = "Updateddate"), NotNull]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "IdOfSharedelement"), NotNull]
        public int IdOfSharedelement { get; set; }

        [Column(Name = "Typeid"), NotNull]
        public int Typeid { get; set; }
    }
}
