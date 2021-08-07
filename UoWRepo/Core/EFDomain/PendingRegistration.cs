using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace UoWRepo.Core.EFDomain
{
    public class PendingRegistration: TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("PendingId")]
        public int Id { get; set; }

        [Column("UserIdTableKey")]
        public int UserIdTableKey { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("UserLastName")]
        public string UserLastName { get; set; }

        [Column("UserLoginName")]
        public string UserLoginName { get; set; }

        [Column("UserCreatedDate")]
        public DateTime UserCreatedDate { get; set; }

        [Column("UserUpdatedDate")]
        public DateTime UserUpdatedDate { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("Id1")]
        public string Id1 { get; set; }

        [Column("Id2")]
        public string Id2 { get; set; }

        [Column("Id3")]
        public string Id3 { get; set; }

        [Column("Id4")]
        public string Id4 { get; set; }

        [Column("EmailMd5")]
        public string EmailMd5 { get; set; }

        [Column("UserLoginNameMd5")]
        public string UserLoginNameMd5 { get; set; }

    }
}