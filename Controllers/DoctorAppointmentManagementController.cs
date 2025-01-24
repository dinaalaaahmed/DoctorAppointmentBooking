using System.Net;
using DoctorAppointmentBooking.Models;
using DoctorAppointmentBooking.Requests;
using DoctorAppointmentBooking.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentBooking.Controllers;

public class DoctorAppointmentManagementController(DoctorAppointmentManagementService service) : Controller
{
    [HttpGet("{doctorId:Guid}/doctor-appointments")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<Appointment>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<List<Appointment>> DoctorAppointments([FromRoute(Name = "doctorId")] Guid doctorId)
    {
        return await service.FindAsync(doctorId);
    }

    [HttpPatch("doctor-appointments/status/{Status:string}")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DoctorSlot>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<bool> DoctorAppointmentStatusUpdate( [FromBody] AppointmentsStatusUpdateRequest request)
    {
        return await service.UpdateStatusesAsync(request.AppointmentIds, Enum.Parse<Status>(request.Status));
    }
}