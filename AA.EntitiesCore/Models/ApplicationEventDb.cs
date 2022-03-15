using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.EntitiesCore.Models
{
    [Table("applicationevents")]
    internal class ApplicationEventDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("applicationid")]
        public Guid ApplicationId { get; set; }

        [Column("title")]
        public String Title { get; set; }

        [Column("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        public ApplicationEventDb(Guid id, Guid applicationId, String title, DateTime createdDateTime)
        {
            Id = id;
            ApplicationId = applicationId;
            Title = title;
            CreatedDateTime = createdDateTime;
        }
    }
}
