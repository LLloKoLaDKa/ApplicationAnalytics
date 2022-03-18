using AA.Domain.Applications.Events;
using AA.EntitiesCore.Extensions;
using AA.EntitiesCore.Models;
using AA.EntitiesCore.Models.Converters;

namespace AA.EntitiesCore.Repositories.Applications.Events
{
    public class ApplicationEventsRepostiory : BaseRepository
    {
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

        public ApplicationEvent[] GetAllEvents()
        {
            return UseContext(context =>
            {
                return context.ApplicationEvents.ToEvents();
            });
        }
    }
}
