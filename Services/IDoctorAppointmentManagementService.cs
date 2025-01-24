using DoctorAppointmentBooking.Models;

namespace DoctorAppointmentBooking.Services;

public interface IDoctorAppointmentManagementService
{
    Task<List<Appointment>> FindAsync(Guid doctorId);
}