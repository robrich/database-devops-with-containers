using Microsoft.EntityFrameworkCore;

namespace WebApp.DataAccess
{
    public class WebAppContext : DbContext
    {
        // FRAGILE: By default, DbSet name is Table name

        public DbSet<Customer> Customer { get; set; }
        public DbSet<InvoiceLog> InvoiceLog { get; set; }
        public DbSet<Setting> Settings { get; set; }

        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
            this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
    }
}
