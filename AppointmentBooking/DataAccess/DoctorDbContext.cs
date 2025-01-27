using System.Reflection;
using DoctorAppointmentBooking.AppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.AppointmentBooking.DataAccess;
public class DoctorDbContext(IConfiguration configuration) : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<DoctorSlot> DoctorSlots => Set<DoctorSlot>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
        .UseNpgsql(configuration.GetConnectionString("DoctorAppointment"))
        .EnableSensitiveDataLogging(configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "local");

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<DoctorSlot>()
            .HasOne(d => d.Appointment)
            .WithOne(a => a.DoctorSlot)
            .HasForeignKey<Appointment>(a => a.SlotId);

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(DoctorDbContext))!);
    }
}