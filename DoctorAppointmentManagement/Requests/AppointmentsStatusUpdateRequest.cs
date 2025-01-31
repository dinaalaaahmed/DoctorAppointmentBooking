using System.Text.Json.Serialization;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.Requests;

public class AppointmentsStatusUpdateRequest
{
    [JsonPropertyName("appointment_ids")]
    public List<Guid> AppointmentIds { set; get; }
    
    [JsonPropertyName("status")]
    public string Status { set; get; }
}