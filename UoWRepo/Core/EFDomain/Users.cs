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
        public string Username { get; set; }

        [Column("UserLastName")]
        public string Userlastname { get; set; }

        [Column("UserLoginName")]
        public string Userloginname { get; set; }

        [Column("UserCreatedDate")]
        public DateTime Usercreateddate { get; set; }

        [Column("UserUpdatedDate")]
        public DateTime UpdatedDate { get; set; }

        [Column("UserPassword")]
        public string Userpassword { get; set; }

        [Column("UserLastLogin")]
        public DateTime Userlastlogin { get; set; }

        [Column("UserRoleLevel")]
        public int Userrolelevel { get; set; }

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
