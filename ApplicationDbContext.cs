using ClinicWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ClinicWebApp
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Booking>()
                .HasKey(b => new { b.PatientID, b.ClinicID });

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Patient)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PatientID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Clinic)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClinicID);
        }
    }
}
