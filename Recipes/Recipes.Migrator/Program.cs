using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Recipes.Core.Application;
using Recipes.Migrator;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddSeqEndpoint(connectionName: "seq");
builder.AddSqlServerClient(connectionName: "database");

builder.Services.AddHostedService<Worker>();

builder.Services.AddApplication(builder.Configuration);

var host = builder.Build();

await host.RunAsync();