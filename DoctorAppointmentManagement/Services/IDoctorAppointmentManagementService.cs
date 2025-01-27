using DoctorAppointmentBooking.DoctorAppointmentManagement.Models;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.Services;

public interface IDoctorAppointmentManagementService
{
    Task<List<Appointment>> FindAsync(Guid doctorId);
    Task<bool> UpdateStatusesAsync(List<Guid> requestAppointmentIds, Status parse);
}