using AA.EntitiesCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AA.EntitiesCore
{
    public class ApplicationAnalyticsContext : DbContext
    {
        private static DbContextOptions<ApplicationAnalyticsContext> _dbContextOptions =
            new DbContextOptionsBuilder<ApplicationAnalyticsContext>()
            .UseNpgsql(@"Server=localhost;Username=aa_admin;Database=applications;Port=5432;Password=95nJJara@x~B")
            .Options;

        internal DbSet<ApplicationDb> Applications { get; set; }
        internal DbSet<ApplicationEventDb> ApplicationEvents { get; set; }
        internal DbSet<UserDb> Users { get; set; }

        public ApplicationAnalyticsContext() : base(_dbContextOptions) { }
    }
}
