
using Innovatech.Api.Infraestructure;
using Innovatech.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Innovatech.Application;

namespace Innovatech.Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<Entities>(options =>
        {
            options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("Entities"));
        });
        builder.Services.AddApplication();
        builder.Services.AddCustomServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
       
        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.InitializeBD();

        app.Run();

    }
}