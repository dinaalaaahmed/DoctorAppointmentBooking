using DoctorAppointmentBooking.DoctorAvailability.DataAccess;
using DoctorAppointmentBooking.DoctorAvailability.Models;

namespace DoctorAppointmentBooking.DoctorAvailability.Services;

public class DoctorAvailabilityService(DoctorAppointmentRepository repo)
{
    public Task<List<DoctorSlot>> FindAll(Guid doctorId)
    {
        return Task.FromResult(repo.FindAll(doctorId));
    }
    
    public async Task<int> AddMany(List<DoctorSlot> doctorSlots)
    {
        return await repo.AddManyAsync(doctorSlots);
    }
 
}