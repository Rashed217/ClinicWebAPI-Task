
using ClinicWebApp.Repositories;
using ClinicWebApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace ClinicWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(local); Initial Catalog=ClinicWebApp; Integrated Security=true; TrustServerCertificate=True");

            var builder = WebApplication.CreateBuilder(args);

            // Connection String

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.

            builder.Services.AddScoped<IPatientRepo, PatientRepo>();
            builder.Services.AddScoped<IClinicRepo, ClinicRepo>();
            builder.Services.AddScoped<IBookingRepo, BookingRepo>();

            builder.Services.AddScoped<IPatientService, PatientService>();
            builder.Services.AddScoped<IClinicService, ClinicService>();
            builder.Services.AddScoped<IBookingService, BookingService>();

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


            app.MapControllers();

            app.Run();
        }

    }
}
