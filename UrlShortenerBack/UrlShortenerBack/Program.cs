using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using UrlShortenerBack.DbContexts;
using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Repositories;
using UrlShortenerBack.Services;

namespace UrlShortenerBack
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Env.Load("../.env");
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddDbContext<UrlContext>(options =>
            {
                options.UseNpgsql(Environment.GetEnvironmentVariable("URL_DATABASE_SETTINGS"));
            });
            
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost",
                    policy => policy
                        .AllowAnyOrigin() // Allows ALL origins (any domain, port, etc.)
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });


            builder.Services.AddScoped<IUrlRepository, UrlRepository>();
            builder.Services.AddScoped<IUrlService, UrlService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<UrlContext>().Database.Migrate();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            app.UseCors("AllowLocalhost");
            
            app.Run();
        }
    }
}