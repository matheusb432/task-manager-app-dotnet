using Microsoft.AspNetCore.OData;
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
    // TODO configure proper cors on production
    //app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
}
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());

app.UseAuthentication();
app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandlerMiddleware();

app.UseHealthChecksConfig();
app.MapControllers();

app.Run();
