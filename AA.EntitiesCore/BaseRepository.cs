using Microsoft.EntityFrameworkCore;
using System;

namespace AA.EntitiesCore
{
    public abstract class BaseRepository
    {
        private DbContextOptions<ApplicationAnalyticsContext> _dbContextOptions;

        public BaseRepository(String? connectionString = null)
        {
            _dbContextOptions =
                new DbContextOptionsBuilder<ApplicationAnalyticsContext>()
                .UseNpgsql(connectionString ?? @"Server=localhost;Username=aa_admin;Database=analytics;Port=65432;Password=95nJJara@x~Bs")
                .Options;
        }

        internal void UseContext(Action<ApplicationAnalyticsContext> action)
        {
            using (ApplicationAnalyticsContext _context = new(_dbContextOptions))
            {
                action(_context);
            }
        }

        internal T UseContext<T>(Func<ApplicationAnalyticsContext, T> action)
        {
            using (ApplicationAnalyticsContext _context = new(_dbContextOptions))
            {
                T result = action(_context);
                return result;
            }
        }
    }
}
