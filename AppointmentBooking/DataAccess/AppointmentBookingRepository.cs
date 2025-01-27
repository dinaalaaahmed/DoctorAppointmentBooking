using DoctorAppointmentBooking.AppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointmentBooking.AppointmentBooking.DataAccess;

public class AppointmentBookingRepository(AppointmentDbContext appointmentDbContext, DoctorDbContext doctorDbContext) : IAppointmentBookingRepository
{
    public Task<List<DoctorSlot>> FindDoctorAvailableSlots(Guid doctorId)
    {
        return Task.FromResult(doctorDbContext.DoctorSlots.Where(x => x.DoctorId == doctorId && x.IsReserved == false).ToList());
    }

    public async Task<int> AddAppointment(Appointment appointment)
    {
        await appointmentDbContext.Appointments.AddAsync(appointment);
        return await appointmentDbContext.SaveChangesAsync();
    }

    public async Task<bool> MarkSlotUnavailable(Guid slotId)
    {
        var result = await doctorDbContext.DoctorSlots
            .Where(x => x.Id == slotId)
            .ExecuteUpdateAsync(f => f
                .SetProperty(x => x.IsReserved, true)
            );

        return result > 0;
    }
}