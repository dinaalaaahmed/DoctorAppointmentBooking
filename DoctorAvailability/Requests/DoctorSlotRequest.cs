using System.Text.Json.Serialization;

namespace DoctorAppointmentBooking.DoctorAvailability.Requests;

public class DoctorSlotsRequest
{
    [JsonPropertyName("doctor_slots")]
    public List<DoctorSlotRequest> DoctorSlots { set; get; }
}
public class DoctorSlotRequest
{
    [JsonPropertyName("time")]
    public DateTime Time { set; get; }
    [JsonPropertyName("doctor_name")]
    public string DoctorName { set; get; }

    [JsonPropertyName("is_reserved")] 
    public bool IsReserved { set; get; } = false;
    [JsonPropertyName("cost")]
    public decimal Cost { set; get; }
    [JsonPropertyName("doctor_id")]
    public string DoctorId { get; set; }
}