using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Recipes.API.Swagger;
using Recipes.Core.Application;
using Recipes.Core.Application.Common.Interfaces;
using Recipes.Filters;
using Recipes.Services;
using Recipes.Security;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;
var isDevelopment = builder.Environment.IsDevelopment();

builder.AddSeqEndpoint(connectionName: "seq");
builder.AddSqlServerClient(connectionName: "database");
builder.AddServiceDefaults();

services.AddApplication(configuration);

services.AddSingleton<ICurrentUserService, CurrentUserService>();
services.AddHttpContextAccessor();

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(configuration);

services.AddAuthorizationPolicies(configuration);

services.AddCorsPolicies();

services.AddControllers(o =>
{
    o.Filters.Add<ApiExceptionFilterAttribute>();
});

services.AddOpenApi();

services.AddCustomSwagger(configuration);

var app = builder.Build();

app.UseCors(isDevelopment ? "Development" : "Production");

app.MapDefaultEndpoints();

if (isDevelopment)
{
    app.MapOpenApi();

    app.UseCustomSwagger(configuration);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
