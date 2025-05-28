using UrlShortenerBack.Interfaces;
using UrlShortenerBack.Repositories;
using UrlShortenerBack.Services;

namespace UrlShortenerBack
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();
            builder.Services.AddLogging();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddScoped<IUrlRepository, UrlRepository>();
            builder.Services.AddScoped<IUrlService, UrlService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.MapControllers();
            
            app.Run();
        }
    }
}