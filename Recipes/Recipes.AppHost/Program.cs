using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var seq = builder.AddSeq("seq")
    .WithDataVolume()
    .ExcludeFromManifest()
    .WithLifetime(ContainerLifetime.Persistent)
    .WithEnvironment("ACCEPT_EULA", "Y");

var sql = builder.AddSqlServer("sql")
    .WithDataVolume()
    .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("database", "Recipes-Teun");

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
