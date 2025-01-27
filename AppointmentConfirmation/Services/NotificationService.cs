using DoctorAppointmentBooking.AppointmentConfirmation.Requests;

namespace DoctorAppointmentBooking.AppointmentConfirmation.Services;

public class NotificationService
{
    public void NotifyPatient(BookAppointmentRequest request)
    {
        Console.WriteLine($"Dear {request.PatientName}, Your Appointment is Confirmed with Doctor {request.DoctorName} At {request.ReservedAt}");
    }

    public void NotifyDoctor(BookAppointmentRequest request)
    {
        Console.WriteLine($"Dear {request.DoctorName}, Your Appointment is Confirmed with Patient {request.PatientName} At {request.ReservedAt}");
    }
}