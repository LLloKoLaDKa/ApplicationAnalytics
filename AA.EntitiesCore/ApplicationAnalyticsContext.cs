using AA.EntitiesCore.Models.Applications;
using AA.EntitiesCore.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace AA.EntitiesCore
{
    public class ApplicationAnalyticsContext : DbContext
    {
        internal DbSet<ApplicationDb> Applications { get; set; }
        internal DbSet<ApplicationEventDb> ApplicationEvents { get; set; }
        internal DbSet<UserDb> Users { get; set; }

        public ApplicationAnalyticsContext(DbContextOptions<ApplicationAnalyticsContext> options) : base(options) { }
    }
}
