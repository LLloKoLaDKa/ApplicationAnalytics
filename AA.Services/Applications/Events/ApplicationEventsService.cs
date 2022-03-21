using AA.Domain.Applications.Events;
using AA.EntitiesCore.Repositories.Applications.Events;
using System;

namespace AA.Services.Applications.Events
{
    public class ApplicationEventsService
    {
        private readonly ApplicationEventsRepostiory _applicationEventsRepository;

        public ApplicationEventsService(String? connectionString = null)
        {
            _applicationEventsRepository = new(connectionString);
        }

        public void SaveEvent(ApplicationEventBlank blank)
        {
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _applicationEventsRepository.SaveEvent(blank);
        }

        public ApplicationEvent[] GetApplicationId(Guid applicationId)
        {
            return _applicationEventsRepository.GetApplicationEvents(applicationId);
        }
    }
}
