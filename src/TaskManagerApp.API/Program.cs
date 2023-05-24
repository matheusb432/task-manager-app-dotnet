using Microsoft.AspNetCore.OData;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Configurations;
using TaskManagerApp.Application.Utils;
using TaskManagerApp.Infra;
using TaskManagerApp.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;
var isDockerInstance = EnvUtils.IsDockerInstance();

services.AddControllers().AddOData(opt => opt.Count().Filter().OrderBy().Select().SetMaxTop(50));

services.AddHealthChecks().AddDbContextCheck<TaskManagerContext>();

services.AddEndpointsApiExplorer();
services.AddSwagger();
services.AddCacheConfiguration();

services.AddApplicationConfig(configuration, isDockerInstance);
services.AddInfraConfiguration(configuration, isDockerInstance);

services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
}
else
{
    var allowedOrigins = Array.Empty<string>();
    if (isDockerInstance)
    {
        allowedOrigins =
            Environment.GetEnvironmentVariable("ALLOWED_ORIGINS")?.Split(';')
            ?? Array.Empty<string>();
    }
    else
    {
        allowedOrigins = configuration.GetSection("AllowedOrigins").Get<string[]>();
    }
    app.UseCors(x => x.WithOrigins(allowedOrigins).AllowAnyMethod().AllowAnyHeader());
}

app.UseAuthentication();
app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandlerMiddleware();

app.UseHealthChecksConfig();
app.MapControllers();

app.Run();
