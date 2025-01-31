namespace DoctorAppointmentBooking.AppointmentBooking.Models;

public class DoctorSlot
{
    public Guid Id { set; get; } = Guid.NewGuid();
    public DateTime Time { set; get; }
    public Guid DoctorId { set; get; }
    public string DoctorName { set; get; }
    public bool IsReserved { set; get; }
    public decimal Cost { set; get; }
    
    public Appointment Appointment { get; set; } // One-to-One relationship
}