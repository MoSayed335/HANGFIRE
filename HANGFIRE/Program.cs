
using DocumentFormat.OpenXml.ExtendedProperties;
using Hangfire;
using Scalar.AspNetCore;
namespace HANGFIRE
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //hangfire settings
            builder.Services.AddHangfire(h => h.UseSqlServerStorage("Server=(localdb)\\ProjectModels;Database=Hangfire;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False"));
            builder.Services.AddHangfireServer();
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            app.UseHangfireDashboard("/hangfire");
            //onlyone working
            //BackgroundJob.Enqueue<Manager>( task => task.Features.FirstOrDefault());
            //BackgroundJob.Enqueue<Manager>(t => t.Equals());

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
