using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.EntitiesCore.Models.Users
{
    [Table("users")]
    internal class UserDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("passwordhash")]
        public string PasswordHash { get; set; }

        [Column("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        public UserDb(Guid id, string email, string passwordHash, DateTime createdDateTime)
        {
            Id = id;
            Email = email;
            PasswordHash = passwordHash;
            CreatedDateTime = createdDateTime;
        }
    }
}
