using DoctorAppointmentBooking.AppointmentBooking.DataAccess;
using DoctorAppointmentBooking.AppointmentBooking.Models;

namespace DoctorAppointmentBooking.AppointmentBooking.UseCases;

public class BookAppointmentUseCase(IAppointmentBookingRepository repository)
{
    public async Task<bool> BookAppointmentAsync(Appointment appointment)
    {
        await repository.MarkSlotUnavailable(appointment.SlotId);
        var result = await repository.AddAppointment(appointment);
        return result > 1;
    }
}