using System;
using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain
{
    [Table(Name = "tb_users")]
    public class Users : Linq2DbEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "userID"), NotNull]
        public int Id { get; set; }

        [Column(Name = "UserName"), NotNull]
        public string UserName { get; set; }

        [Column(Name = "UserLastName"), NotNull]
        public string UserLastName { get; set; }

        [Column(Name = "UserLoginName"), NotNull]
        public string UserLoginName { get; set; }

        [Column(Name = "UserCreatedDate"), NotNull]
        public DateTime UserCreateDate { get; set; }

        [Column(Name = "UserUpdatedDate"), NotNull]
        public DateTime UpdatedDate { get; set; }

        [Column(Name = "UserPassword"), NotNull]
        public string UserPassword { get; set; }

        [Column(Name = "UserLastLogin"), NotNull]
        public DateTime UserLastLogin { get; set; }

        [Column(Name = "UserRoleLevel"), NotNull]
        public int UserRoleLevel { get; set; }

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
