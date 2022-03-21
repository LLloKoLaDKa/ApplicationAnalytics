using AA.Domain.Applications;
using AA.EntitiesCore.Extensions;
using AA.EntitiesCore.Models.Applications;
using AA.EntitiesCore.Models.Applications.Converters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace AA.EntitiesCore.Repositories.Applications
{
    public class ApplicationsRepository : BaseRepository
    {
        public void SaveApp(ApplicationBlank blank)
        {
            UseContext(context =>
            {
                ApplicationDb db = blank.ToDb();

                context.Attach(db);
                context.Applications.AddOrUpdate(db, context);
                context.SaveChanges();
                context.Database.Migrate();
            });
        }

        public Int32 GetCountForUser(Guid userId)
        {
            return UseContext(context =>
            {
                return context.Applications.Where(a => a.UserId == userId && !a.IsRemoved).Count();
            });
        }

        public Application[] GetApplications(Guid userId)
        {
            return UseContext(context =>
            {
                return context.Applications.Where(a => a.UserId == userId && !a.IsRemoved).ToApplications();
            });
        }

        public void DeleteApp(Guid applicationId)
        {
            UseContext(context =>
            {
                ApplicationDb db = context.Applications.FirstOrDefault(a => a.Id == applicationId);
                if (db is null) return;

                db.IsRemoved = true;
                context.Entry(db).State = EntityState.Modified;
                context.SaveChanges();
            });
        }
    }
}
