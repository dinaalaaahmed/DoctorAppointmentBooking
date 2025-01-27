using System.Reflection;
using DoctorAppointmentBooking.DoctorAppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.DataAccess;
public class AppointmentDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseNpgsql(configuration.GetConnectionString("DoctorAppointment"))
        .EnableSensitiveDataLogging(configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "local");

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.Entity<Appointment>().HasOne(d => d.DoctorSlot)
            .WithOne(a => a.Appointment)
            .HasForeignKey<Appointment>(a => a.SlotId);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Appointment))!);
    }
}