using System;
using LinqToDB.Mapping;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    public class PendingRegistration: TEntity, ITEntity
    {
        [PrimaryKey, Identity]
        [Column(Name = "PendingId"), NotNull]
        public int Id { get; set; }

        [Column(Name = "UserIdTableKey"), NotNull]
        public int UserIdTableKey { get; set; }

        [Column(Name = "UserName"), NotNull]
        public string UserName { get; set; }

        [Column(Name = "UserLastName"), NotNull]
        public string UserLastName { get; set; }

        [Column(Name = "UserLoginName"), NotNull]
        public string UserLoginName { get; set; }

        [Column(Name = "UserCreatedDate"), NotNull]
        public DateTime UserCreatedDate { get; set; }

        [Column(Name = "UserUpdatedDate"), NotNull]
        public DateTime UserUpdatedDate { get; set; }

        [Column(Name = "Email"), NotNull]
        public string Email { get; set; }

        [Column(Name = "Id1"), NotNull]
        public string Id1 { get; set; }

        [Column(Name = "Id2"), NotNull]
        public string Id2 { get; set; }

        [Column(Name = "Id3"), NotNull]
        public string Id3 { get; set; }

        [Column(Name = "Id4"), NotNull]
        public string Id4 { get; set; }

        [Column(Name = "EmailMd5"), NotNull]
        public string EmailMd5 { get; set; }

        [Column(Name = "UserLoginNameMd5"), NotNull]
        public string UserLoginNameMd5 { get; set; }

    }
}