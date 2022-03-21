using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.EntitiesCore.Models.Applications
{
    [Table("applications")]
    internal class ApplicationDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("userid")]
        public Guid UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        [Column("isremoved")]
        public bool IsRemoved { get; set; }

        public ApplicationDb(Guid id, Guid userId, string name, DateTime createdDateTime, bool isRemoved = false)
        {
            Id = id;
            UserId = userId;
            Name = name;
            CreatedDateTime = createdDateTime;
            IsRemoved = isRemoved;
        }
    }
}
