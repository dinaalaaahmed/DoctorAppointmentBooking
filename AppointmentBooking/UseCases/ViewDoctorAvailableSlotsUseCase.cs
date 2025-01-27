using DoctorAppointmentBooking.AppointmentBooking.DataAccess;
using DoctorAppointmentBooking.AppointmentBooking.Models;

namespace DoctorAppointmentBooking.AppointmentBooking.UseCases;

public class ViewDoctorAvailableSlotsUseCase(IAppointmentBookingRepository repository)
{
    public async Task<List<DoctorSlot>> ViewDoctorAvailableSlots(Guid doctorId)
    {
        return await repository.FindDoctorAvailableSlots(doctorId);
    }
}