using System;

namespace AA.EntitiesCore
{
    public abstract class BaseRepository
    {
        internal void UseContext(Action<ApplicationAnalyticsContext> action)
        {
            using (ApplicationAnalyticsContext _context = new())
            {
                action(_context);
            }
        }

        internal T UseContext<T>(Func<ApplicationAnalyticsContext, T> action)
        {
            using (ApplicationAnalyticsContext _context = new())
            {
                T result = action(_context);
                return result;
            }
        }
    }
}
