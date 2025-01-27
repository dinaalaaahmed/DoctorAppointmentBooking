namespace DoctorAppointmentBooking.AppointmentBooking.Requests;

public class BookAppointmentRequest
{
    public Guid PatientId { set; get; }
    public string PatientName { set; get; }
    public DateTime ReservedAt { set; get; }
    public Guid SlotId { set; get; }
}