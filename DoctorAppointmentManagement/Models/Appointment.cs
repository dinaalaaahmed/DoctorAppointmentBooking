
using DoctorAppointmentBooking.DoctorAvailability.Models;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.Models;

public class Appointment
{
    public Guid Id { set; get; } = Guid.NewGuid();
    public Guid PatientId { set; get; }
    public string PatientName { set; get; }
    public DateTime ReservedAt { set; get; }
    public Status Status { set; get; }
    
    public Guid SlotId { set; get; }
    
    public DoctorSlot DoctorSlot { get; set; } // Navigation Property
}

public enum Status
{
    Cancelled,
    Completed,
    Booked
}