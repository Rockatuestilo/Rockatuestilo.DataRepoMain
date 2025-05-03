using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain;

[Table("SharingSocialNetwork")]
public class SharingSocialNetworkLinqDB : TEntity, ITEntity
{
    [Column("Nameofsocialnetwork")]
    public string Nameofsocialnetwork { get; set; }

}