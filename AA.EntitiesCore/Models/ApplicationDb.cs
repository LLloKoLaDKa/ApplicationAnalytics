using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.EntitiesCore.Models
{
    [Table("applications")]
    internal class ApplicationDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("userid")]
        public Guid UserId { get; set; }

        [Column("name")]
        public String Name { get; set; }

        [Column("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("isremoved")]
        public Boolean IsRemoved { get; set; }

        public ApplicationDb(Guid id, Guid userId, String name, DateTime createdDateTime, Boolean isRemoved = false)
        {
            Id = id;
            UserId = userId;
            Name = name;
            CreatedDateTime = createdDateTime;
            IsRemoved = isRemoved;
        }
    }
}
