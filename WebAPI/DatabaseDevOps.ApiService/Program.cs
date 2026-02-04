
using DatabaseDevOps.ApiService;

var builder = WebApplication.CreateBuilder(args);

// Add SQL Server
builder.AddSqlServerDbContext<DatabaseDevOpsDbContext>("WebApp"); // <-- matches database name in AppHost

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Swagger/OpenAPI (Swashbuckle)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Database DevOps with Containers API v1"));
	app.MapOpenApi();
}

app.MapGet("/", () => "API service is running. Navigate to /swagger to see the APIs.");

// id is page number, base 0
app.MapGet("/customers/{id?}", async (int? id, DatabaseDevOpsDbContext db) =>
{
	int page = id ?? 0;
	if (page < 0)
	{
		page = 0;
	}
	int pageSize = 24;
	List<Customer> customers = await (
		from c in db.Customer
		orderby c.CustomerId
		select c
	).Skip(page * pageSize).Take(pageSize).ToListAsync();
	return new CustomerViewModel
	{
		Customers = customers,
		Page = page
	};
});

// id is page number, base 0
app.MapGet("/invoicelogs/{id?}", async (int? id, DatabaseDevOpsDbContext db) =>
{
	int page = id ?? 0;
	if (page < 0)
	{
		page = 0;
	}
	int pageSize = 24;
	List<InvoiceLog> logs = await (
		from i in db.InvoiceLog
		orderby i.InvoiceLogId
		select i
	).Skip(page * pageSize).Take(pageSize).ToListAsync();
	return new InvoiceLogViewModel
	{
		InvoiceLogs = logs,
		Page = page
	};
});

// FRAGILE: are we leaking secrets?
app.MapGet("/settings", (DatabaseDevOpsDbContext db) =>
	(
		from i in db.Settings
		orderby i.Name
		select i
	).ToList());

app.MapDefaultEndpoints();

app.Run();
