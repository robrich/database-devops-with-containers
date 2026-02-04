namespace DatabaseDevOps.ApiService;

public class DatabaseDevOpsDbContext : DbContext
{
	public DatabaseDevOpsDbContext(DbContextOptions<DatabaseDevOpsDbContext> options) : base(options)
	{
		this.ChangeTracker.LazyLoadingEnabled = false;
		this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
	}

	// FRAGILE: By default, DbSet name is Table name
	public DbSet<Customer> Customer => Set<Customer>();
    public DbSet<InvoiceLog> InvoiceLog => Set<InvoiceLog>();
    public DbSet<Setting> Settings => Set<Setting>();
}
