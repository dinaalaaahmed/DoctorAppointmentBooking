using System.Reflection;
using DoctorAppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.DataAccess;
public class DoctorDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<DoctorSlot> DoctorSlots => Set<DoctorSlot>();
    public DbSet<Appointment> Appointments => Set<Appointment>();


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseNpgsql(configuration.GetConnectionString("DoctorAppointment"))
        .EnableSensitiveDataLogging(configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "local");

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DoctorDbContext))!);
}