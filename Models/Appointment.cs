namespace DoctorAppointmentBooking.Models;

public class Appointment
{
    public Guid Id { set; get; } = Guid.NewGuid();
    public Guid SlotId { set; get; }
    public Guid PatientId { set; get; }
    public string PatientName { set; get; }
    public DateTime ReservedAt { set; get; }
    public Status Status { set; get; }
}

public enum Status
{
    Cancelled,
    Completed,
    Booked
}