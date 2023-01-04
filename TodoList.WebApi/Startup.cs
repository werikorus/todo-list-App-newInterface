using System;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TodoList.Repositories.Contexts;
using Microsoft.Extensions.Configuration;
using TodoList.Services.Mappers;
using AutoMapper;
using TodoList.Repositories.Ioc;
using TodoList.Services.Ioc;
namespace TodoList.WebApi;

public class Startup
{
    protected readonly IHostEnvironment HostEnvironment;
    public IConfiguration Configuration  { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers();
        services.AddApiVersioning();

        services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false)
            .AddFluentValidation();

        services.AddDbContext(Configuration);
        services.AddRepository();

        services.AddAutoMapper();
        services.AddService();

        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen(c =>
        {
            c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "To Do List Api",
                Version = "v1"
            });
        });
    }

    public void Configure(IApplicationBuilder app,  IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "To Do List Api v1"));
        }

        app.UseRouting();

        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());

        app.UseEndpoints(endpoints => endpoints.MapControllers());
        
    }

    protected void ConfigureAutoMapper(IServiceProvider services, IMapperConfigurationExpression configuration)
    {
        configuration.AddMaps(new []
        {
           typeof(ModelToDomainProfile).Assembly
        });
    }
    
}