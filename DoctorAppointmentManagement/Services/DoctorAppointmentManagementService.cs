using DoctorAppointmentBooking.DoctorAppointmentManagement.DataAccess;
using DoctorAppointmentBooking.DoctorAppointmentManagement.Models;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.Services;

public class DoctorAppointmentManagementService(IDoctorAppointmentManagementRepository repository) : IDoctorAppointmentManagementService
{
    public Task<List<Appointment>> FindAsync(Guid doctorId)
    {
        return Task.FromResult(repository.FindAll(doctorId));
    }

    public async Task<bool> UpdateStatusesAsync(List<Guid> appointmentIds, Status status)
    {
        return await repository.UpdateStatusAsync(appointmentIds, status);
    }
}