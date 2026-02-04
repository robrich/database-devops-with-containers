var builder = DistributedApplication.CreateBuilder(args);

var password = builder.AddParameter("password"); // D3vP@ssw0rd

// Add a SQL Server container resource and a database inside it
var mssql = builder.AddSqlServer("mssql", password)
    .WithImageRegistry("").WithImage("dev-database", "latest"); // <-- the custom image we just built
    //.WithLifetime(ContainerLifetime.Persistent); // <-- don't want to wait for it to spin up each time?

var webappdb = mssql.AddDatabase("WebApp");

var apiService = builder.AddProject<Projects.DatabaseDevOps_ApiService>("apiservice")
    .WithHttpHealthCheck("/health")
    .WithReference(webappdb).WaitFor(webappdb);

builder.AddProject<Projects.DatabaseDevOps_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
