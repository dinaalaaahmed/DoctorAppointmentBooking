using DoctorAppointmentBooking.Models;

namespace DoctorAppointmentBooking.DataAccess;

public interface IDoctorAppointmentManagementRepository
{
    List<Appointment> FindAll(Guid doctorId);
    Task<bool> UpdateStatusAsync(List<Guid> appointmentIds, Status status);
}