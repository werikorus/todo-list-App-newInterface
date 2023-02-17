using System.Text;
using TodoList.Services.Mappers;
using AutoMapper;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using TodoList.Repositories.Interfaces;
using TodoList.Repositories.Ioc;
using TodoList.Repositories.Repositories;
using TodoList.Services;
using TodoList.Services.Ioc;
using TodoList.WebApi.Graph.User;
using TodoList.WebApi.Ioc;

namespace TodoList.WebApi;

public class Startup
{
    protected readonly IHostEnvironment HostEnvironment;
    public Startup(IConfiguration configuration) => Configuration = configuration;
    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddControllers()
            .AddNewtonsoftJson(options
                => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        services.AddApiVersioning();

        services.AddMvcCore(options => options.SuppressAsyncSuffixInActionNames = false)
            .AddFluentValidation();

        services.AddDbContext(Configuration);
        services.RegisterServices();
        services.AddRepository();
        services.AddAutoMapper();
        services.ConfigureGraphQlServices(Configuration, HostEnvironment);
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

        services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "To Do List Api v1"));
        }

        app.UseHttpsRedirection();
        app.UseRouting();
        
        app.UseGraphQLPlayground();

        app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true));
        
        app.UseAuthorization();
        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }

    protected void ConfigureAutoMapper(IServiceProvider services, IMapperConfigurationExpression configuration)
    {
        configuration.AddMaps(new[]
        {
            typeof(ModelToDomainProfile).Assembly
        });
    }
}