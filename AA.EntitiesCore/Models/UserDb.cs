using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.EntitiesCore.Models
{
    [Table("users")]
    internal class UserDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("email")]
        public String Email { get; set; }

        [Column("passwordhash")]
        public String PasswordHash { get; set; }

        [Column("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        public UserDb(Guid id, String email, String passwordHash, DateTime createdDateTime)
        {
            Id = id;
            Email = email;
            PasswordHash = passwordHash;
            CreatedDateTime = createdDateTime;
        }
    }
}
