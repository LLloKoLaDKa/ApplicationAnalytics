using System;

namespace AA.Domain.Applications.Events
{
    public class ApplicationEvent
    {
        public Guid Id { get; }
        public Guid ApplicationId { get; }
        public String Title { get; }

        public ApplicationEvent(Guid id, Guid applicationId, String title)
        {
            Id = id;
            ApplicationId = applicationId;
            Title = title;
        }
    }
}
