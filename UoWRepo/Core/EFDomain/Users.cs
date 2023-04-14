using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UoWRepo.Core.EFDomain
{
    [Table("tb_users")]
    public class Users : TEntity, ITEntity
    {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        [Column("userID")]
        public int Id { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("UserLastName")]
        public string UserLastName { get; set; }

        [Column("UserLoginName")]
        public string UserLoginName { get; set; }

        [Column("UserCreatedDate")]
        public DateTime UserCreatedDate { get; set; }

        [Column("UserUpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [Column("UserPassword")]
        public string UserPassword { get; set; }

        [Column("UserLastLogin")]
        public DateTime UserLastLogin { get; set; }

        [Column("UserRoleLevel")]
        public int UserRoleLevel { get; set; }

        [Column("createdBy")]
        public int CreatedBy { get; set; }

        [Column("updatedBy")]
        public int UpdatedBy { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("verifiedaccount")]
        public bool VerifiedAccount { get; set; }
    }
}
