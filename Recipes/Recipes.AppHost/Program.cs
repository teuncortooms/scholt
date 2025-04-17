using Microsoft.Extensions.Configuration;
using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var seq = builder.AddSeq("seq")
    .ExcludeFromManifest()
    .WithEnvironment("ACCEPT_EULA", "Y");

var sql = builder.AddSqlServer("sql", null, 50688);

var db = sql.AddDatabase("database", "Recipes-Teun");

var isTestRun = builder.Configuration.GetValue("isTestRun", false);
if (!isTestRun)
{
    sql.WithLifetime(ContainerLifetime.Persistent).WithDataVolume();
    seq.WithLifetime(ContainerLifetime.Persistent).WithDataVolume();
}

var migrator = builder.AddProject<Recipes_Migrator>("migrator")
    .WithReference(seq)
    .WaitFor(seq)
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Recipes_API>("recipes")
    .WithReference(seq)
    .WaitFor(seq)
    .WithReference(db)
    .WaitFor(db)
    .WaitForCompletion(migrator);

builder.Build().Run();
