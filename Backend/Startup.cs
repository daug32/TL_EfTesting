using TodoList.Api;
using Microsoft.OpenApi.Models;
using TodoList.Infrastructure;
using TodoList.Api.Services;
using TodoList.Application.Services;
using TodoList.Application.Repositories;
using TodoList.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace TodoList;

public class Startup
{
    public IConfiguration Configuration;

    public Startup( IConfiguration configuration )
    {
        Configuration = configuration;
    }

    public void ConfigureServices( IServiceCollection services )
    {
        services.AddDbContext<TodoListDbContext>( 
            x => x.UseSqlServer( Configuration.GetConnectionString( "TodoList" ) ) );
        services.AddScoped<ITodoRepository, TodoRepository>();
        services.AddScoped<ITodoService, TodoService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddControllers();
        services.AddSwaggerGen( c =>
        {
            c.SwaggerDoc( "v1", new OpenApiInfo { Title = "TodoList", Version = "v1" } );
        } );
    }

    public void Configure( IApplicationBuilder app, IWebHostEnvironment env )
    {
        if ( env.IsDevelopment() )
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI( c => c.SwaggerEndpoint( "/swagger/v1/swagger.json", "TodoList v1" ) );
        }

        app.UseRouting();

        app.UseEndpoints( endpoints =>
        {
            endpoints.MapControllers();
        } );
    }
}
