using System;

namespace AA.Domain.Applications.Events
{
    public class ApplicationEventBlank
    {
        public Guid? Id { get; }
        public Guid? ApplicationId { get; }
        public String? Title { get; }

        public ApplicationEventBlank(Guid? id, Guid? applicationId, String? title)
        {
            Id = id;
            ApplicationId = applicationId;
            Title = title;
        }
    }
}