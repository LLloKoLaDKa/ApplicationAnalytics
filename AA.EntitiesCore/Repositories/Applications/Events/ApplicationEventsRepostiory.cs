using AA.Domain.Applications.Events;
using AA.EntitiesCore.Extensions;
using AA.EntitiesCore.Models.Applications;
using AA.EntitiesCore.Models.Applications.Converters;
using System;
using System.Linq;

namespace AA.EntitiesCore.Repositories.Applications.Events
{
    public class ApplicationEventsRepostiory : BaseRepository
    {
        public ApplicationEventsRepostiory(String? connectionString = null) : base(connectionString) { }

        public void SaveEvent(ApplicationEventBlank blank)
        {
            UseContext(context =>
            {
                ApplicationEventDb db = blank.ToDb();

                context.Attach(db);
                context.ApplicationEvents.AddOrUpdate(db, context);
                context.SaveChanges();
            });
        }

        public ApplicationEvent[] GetApplicationEvents(Guid applicationId)
        {
            return UseContext(context =>
            {
                return context.ApplicationEvents.Where(e => e.ApplicationId == applicationId).ToEvents();
            });
        }
    }
}
