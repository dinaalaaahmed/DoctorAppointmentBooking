using DoctorAppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAppointmentBooking.DataAccess;

public class DoctorAppointmentManagementConfiguration : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.ToTable("doctor_appointment_management").HasKey(e => e.Id);

        builder.Property(e => e.Id).HasColumnName("id").IsRequired();
        builder.Property(e => e.SlotId).HasColumnName("slot_id").IsRequired();
        builder.Property(e => e.PatientId).HasColumnName("patient_id").IsRequired();
        builder.Property(e => e.ReservedAt).HasColumnName("reserved_at");
        builder.Property(e => e.Status).HasColumnName("status").HasDefaultValue(Status.Booked);
        builder.Property(e => e.PatientName).HasColumnName("patient_name");
    }
}