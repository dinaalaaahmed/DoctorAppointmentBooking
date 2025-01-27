using DoctorAppointmentBooking.DoctorAppointmentManagement.Models;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.DataAccess;

public interface IDoctorAppointmentManagementRepository
{
    List<Appointment> FindAll(Guid doctorId);
    Task<bool> UpdateStatusAsync(List<Guid> appointmentIds, Status status);
}