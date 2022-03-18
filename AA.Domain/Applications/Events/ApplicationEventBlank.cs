using System;

namespace AA.Domain.Applications.Events
{
    public class ApplicationEventBlank
    {
        public Guid? Id { get; set; }
        public Guid? ApplicationId { get; set; }
        public ApplicationEventType? Type { get; set; }

        public ApplicationEventBlank(Guid? id, Guid? applicationId, ApplicationEventType? type)
        {
            Id = id;
            ApplicationId = applicationId;
            Type = type;
        }
    }
}