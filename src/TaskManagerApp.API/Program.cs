using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TaskManagerApp.API.Configurations;
using TaskManagerApp.Application.Configurations;
using TaskManagerApp.Infra.Configurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddControllers().AddOData(
    opt => opt.Count().Filter().OrderBy().SetMaxTop(50));

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddApplicationDependencyInjectionConfig();
services.AddInfraConfiguration(configuration);

services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandlerMiddleware();

app.MapControllers();

app.Run();