using System;

namespace AA.Domain.Applications.Events
{
    public class ApplicationEvent
    {
        public Guid Id { get; }
        public Guid ApplicationId { get; }
        public ApplicationEventType Type { get; }

        public ApplicationEvent(Guid id, Guid applicationId, ApplicationEventType type)
        {
            Id = id;
            ApplicationId = applicationId;
            Type = type;
        }
    }
}
