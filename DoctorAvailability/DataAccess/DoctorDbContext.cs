using System.Reflection;
using DoctorAppointmentBooking.DoctorAvailability.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.DoctorAvailability.DataAccess;
public class DoctorDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<DoctorSlot> DoctorSlots => Set<DoctorSlot>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseNpgsql(configuration.GetConnectionString("DoctorAppointment"))
        .EnableSensitiveDataLogging(configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "local");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DoctorSlot>();

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DoctorDbContext))!);
    }
}