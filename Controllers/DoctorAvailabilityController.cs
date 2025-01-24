using System.ComponentModel.DataAnnotations;
using System.Net;
using DoctorAppointmentBooking.Models;
using DoctorAppointmentBooking.Requests;
using DoctorAppointmentBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentBooking.Controllers;

public class DoctorAvailabilityController(DoctorAvailabilityService service) : Controller
{
    [HttpGet("{doctorId:Guid}/doctor-availability")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DoctorSlot>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public Task<List<DoctorSlot>> DoctorAvailability(Guid doctorId)
    {
        return service.FindAll(doctorId);
    }

    [HttpPost("doctor-availability")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DoctorSlot>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<int> DoctorAvailability( [FromBody] DoctorSlotsRequest request)
    {
        var doctorSlotsMapped = request.DoctorSlots.Select(slot => new DoctorSlot
        {
            Time = slot.Time,
            Cost = slot.Cost,
            IsReserved = slot.IsReserved,
            DoctorName = slot.DoctorName,
            DoctorId = new Guid(slot.DoctorId),
            Id = Guid.NewGuid()
        }).ToList();
        return await service.AddMany(doctorSlotsMapped);
    }
}