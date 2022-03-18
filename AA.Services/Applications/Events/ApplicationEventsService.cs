using AA.Domain.Applications.Events;
using AA.EntitiesCore.Repositories.Applications.Events;
using System;

namespace AA.Services.Applications.Events
{
    public class ApplicationEventsService
    {
        private readonly ApplicationEventsRepostiory _applicationEventsRepository;

        public ApplicationEventsService()
        {
            _applicationEventsRepository = new();
        }

        public void SaveEvent(ApplicationEventBlank blank)
        {
            if (blank.Id is null) blank.Id = Guid.NewGuid();

            _applicationEventsRepository.SaveEvent(blank);
        }

        public ApplicationEvent[] GetAllEvents()
        {
            return _applicationEventsRepository.GetAllEvents();
        }
    }
}
