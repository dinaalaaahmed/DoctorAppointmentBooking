using DoctorAppointmentBooking.AppointmentBooking.Models;

namespace DoctorAppointmentBooking.AppointmentBooking.DataAccess;

public interface IAppointmentBookingRepository
{
    Task<List<DoctorSlot>> FindDoctorAvailableSlots(Guid doctorId);
    Task<int> AddAppointment(Appointment appointment);
    Task<bool> MarkSlotUnavailable(Guid slotId);
}