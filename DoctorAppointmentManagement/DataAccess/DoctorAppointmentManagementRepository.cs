using DoctorAppointmentBooking.DoctorAppointmentManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.DataAccess;

public class DoctorAppointmentManagementRepository(AppointmentDbContext dbContext) : IDoctorAppointmentManagementRepository
{
    public List<Appointment> FindAll(Guid doctorId)
    {
        return
            dbContext.Appointments
                .Where(x => x.DoctorSlot.DoctorId == doctorId)
                .Select(x => new Appointment
                {
                    SlotId = x.DoctorSlot.Appointment.SlotId,
                    ReservedAt = x.ReservedAt,
                    PatientId = x.PatientId,
                    PatientName = x.PatientName,
                    Id = x.Id
                })
                .ToList();
    }

    public async Task<bool> UpdateStatusAsync(List<Guid> appointmentIds, Status status)
    {
        var result = await dbContext.Appointments
            .Where(x => appointmentIds.Contains(x.Id))
            .ExecuteUpdateAsync(f => f
                .SetProperty(x => x.Status, status)
            );

        return result > 0;
    }
}