using AA.Domain.Applications.Events;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AA.EntitiesCore.Models.Applications
{
    [Table("applicationevents")]
    internal class ApplicationEventDb
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("applicationid")]
        public Guid ApplicationId { get; set; }

        [Column("type")]
        public ApplicationEventType Type { get; set; }

        [Column("createddatetime")]
        public DateTime CreatedDateTime { get; set; }

        public ApplicationEventDb(Guid id, Guid applicationId, ApplicationEventType type, DateTime createdDateTime)
        {
            Id = id;
            ApplicationId = applicationId;
            Type = type;
            CreatedDateTime = createdDateTime;
        }
    }
}
