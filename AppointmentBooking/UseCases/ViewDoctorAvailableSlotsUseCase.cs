using DoctorAppointmentBooking.AppointmentBooking.DataAccess;
using DoctorAppointmentBooking.DoctorAvailability.Models;
using DoctorSlot = DoctorAppointmentBooking.AppointmentBooking.Models.DoctorSlot;

namespace DoctorAppointmentBooking.AppointmentBooking.UseCases;

public class ViewDoctorAvailableSlotsUseCase(IAppointmentBookingRepository repository)
{
    public async Task<List<DoctorSlot>> ViewDoctorAvailableSlots(Guid doctorId)
    {
        return await repository.FindDoctorAvailableSlots(doctorId);
    }
}