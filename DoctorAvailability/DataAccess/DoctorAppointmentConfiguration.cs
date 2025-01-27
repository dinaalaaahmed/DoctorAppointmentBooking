using DoctorAppointmentBooking.DoctorAvailability.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAppointmentBooking.DoctorAvailability.DataAccess;

public class DoctorAppointmentConfiguration : IEntityTypeConfiguration<DoctorSlot>
{
    public void Configure(EntityTypeBuilder<DoctorSlot> builder)
    {
        builder.ToTable("doctor_slot").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.DoctorId).HasColumnName("doctor_id").IsRequired();

        builder.Property(e => e.Time).HasColumnName("time");
        builder.Property(e => e.DoctorName).HasColumnName("doctor_name");
        builder.Property(e => e.IsReserved).HasColumnName("is_reserved").IsRequired();
        builder.Property(e => e.Cost).HasColumnName("cost");
    }
}