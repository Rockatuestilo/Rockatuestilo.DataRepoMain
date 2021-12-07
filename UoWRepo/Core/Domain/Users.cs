using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    [Table(Name = "tb_users")]
    public class Users : TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "userID"), NotNull]
        public int Id { get; set; }

        [Column(Name = "UserName"), NotNull]
        public string Username { get; set; }

        [Column(Name = "UserLastName"), NotNull]
        public string Userlastname { get; set; }

        [Column(Name = "UserLoginName"), NotNull]
        public string Userloginname { get; set; }

        [Column(Name = "UserCreatedDate"), NotNull]
        public DateTime Usercreateddate { get; set; }

        [Column(Name = "UserUpdatedDate"), NotNull]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "UserPassword"), NotNull]
        public string Userpassword { get; set; }

        [Column(Name = "UserLastLogin"), NotNull]
        public DateTime Userlastlogin { get; set; }

        [Column(Name = "UserRoleLevel"), NotNull]
        public int Userrolelevel { get; set; }

        [Column(Name = "createdBy"), NotNull]
        public int CreatedBy { get; set; }

        [Column(Name = "updatedBy"), NotNull]
        public int UpdatedBy { get; set; }

        [Column(Name = "email"), Nullable]
        public string Email { get; set; }

        [Column(Name = "verifiedaccount"), Nullable]
        public bool VerifiedAccount { get; set; }
    }
}
