using DoctorAppointmentBooking.AppointmentConfirmation.Requests;

namespace DoctorAppointmentBooking.AppointmentConfirmation.Services;

public class ConfirmAppointmentService(NotificationService notificationService)
{
    public Task<bool> ConfirmAppointmentAsync(BookAppointmentRequest request)
    {
        
        notificationService.NotifyPatient(request);
        notificationService.NotifyDoctor(request);
        return Task.FromResult(true);
    }
}