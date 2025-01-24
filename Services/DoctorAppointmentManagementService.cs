using DoctorAppointmentBooking.DataAccess;
using DoctorAppointmentBooking.Models;

namespace DoctorAppointmentBooking.Services;

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