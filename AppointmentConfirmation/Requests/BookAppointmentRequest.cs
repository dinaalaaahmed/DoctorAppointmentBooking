namespace DoctorAppointmentBooking.AppointmentConfirmation.Requests;

public class BookAppointmentRequest
{
    public string PatientName { set; get; }
    public DateTime ReservedAt { set; get; }
    public string DoctorName { get; set; }
}