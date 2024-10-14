using BackendApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<VitalityMasteryContext>(
                options => options.UseSqlServer(builder.Configuration["ConnectionStrings"]));

            builder.Services.AddCors(o => o.AddPolicy("MyPolicy",builder =>
            {
                builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod();
            }));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("MyPolicy");

            app.MapControllers();

            app.Run();
        }
    }
}
