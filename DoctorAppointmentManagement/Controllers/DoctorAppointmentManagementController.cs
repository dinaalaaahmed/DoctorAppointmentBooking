using System.Net;
using DoctorAppointmentBooking.DoctorAppointmentManagement.Models;
using DoctorAppointmentBooking.DoctorAppointmentManagement.Requests;
using DoctorAppointmentBooking.DoctorAppointmentManagement.Services;
using DoctorAppointmentBooking.DoctorAvailability.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentBooking.DoctorAppointmentManagement.Controllers;

public class DoctorAppointmentManagementController(IDoctorAppointmentManagementService service) : Controller
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