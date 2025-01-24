using DoctorAppointmentBooking.Models;
using Microsoft.EntityFrameworkCore;


namespace DoctorAppointmentBooking.DataAccess;

public class DoctorAppointmentRepository(DoctorDbContext dbContext)
{
    public List<DoctorSlot> FindAll(Guid doctorId)
    {
        return dbContext.DoctorSlots.Where(x => x.DoctorId == doctorId).ToList();
    }
    
    public async Task<int> AddManyAsync(IEnumerable<DoctorSlot> doctorSlots)
    {
        await dbContext.DoctorSlots.AddRangeAsync(doctorSlots);
        return await dbContext.SaveChangesAsync();
    }
}
