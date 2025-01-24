using DoctorAppointmentBooking.DataAccess;
using DoctorAppointmentBooking.Models;

namespace DoctorAppointmentBooking.Services;

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