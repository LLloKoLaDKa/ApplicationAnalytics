using AA.Domain.Applications;
using AA.Domain.Applications.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AA.EntitiesCore.Models.Converters
{
    internal static class ApplicationsConverters
    {
        internal static Application ToApplication(this ApplicationDb db)
        {
            return new(db.Id, db.UserId, db.Name, db.CreatedDateTime);
        }

        internal static Application[] ToApplications(this IEnumerable<ApplicationDb> dbs)
        {
            return dbs.Select(ToApplication).ToArray();
        }

        internal static ApplicationDb ToDb(this ApplicationBlank blank)
        {
            return new(blank.Id.Value, blank.UserId.Value, blank.Name, DateTime.Now);
        }

        #region Events

        internal static ApplicationEvent ToEvent(this ApplicationEventDb db)
        {
            return new(db.Id, db.ApplicationId, db.Type);
        }

        internal static ApplicationEvent[] ToEvents(this IEnumerable<ApplicationEventDb> dbs)
        {
            return dbs.Select(ToEvent).ToArray();
        }

        internal static ApplicationEventDb ToDb(this ApplicationEventBlank blank)
        {
            return new(blank.Id.Value, blank.ApplicationId.Value, blank.Type.Value, DateTime.Now);
        }

        #endregion
    }
}
