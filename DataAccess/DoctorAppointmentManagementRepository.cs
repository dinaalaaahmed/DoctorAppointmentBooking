using DoctorAppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.DataAccess;

public class DoctorAppointmentManagementRepository(DoctorDbContext dbContext) : IDoctorAppointmentManagementRepository
{
    public List<Appointment> FindAll(Guid doctorId)
    {
        return 
            dbContext.DoctorSlots
            .Join(dbContext.Appointments,
                doctor => doctor.Id,
                appointment => appointment.SlotId,
                (doctor, appointment) => new { doctor.DoctorId, Appointment = appointment })
            .Where(x => x.DoctorId == doctorId)
            .Select(x => new Appointment
            {
                SlotId = x.Appointment.SlotId,
                ReservedAt = x.Appointment.ReservedAt,
                PatientId = x.Appointment.PatientId,
                PatientName = x.Appointment.PatientName,
                Id = x.Appointment.Id
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