using System.Net;
using DoctorAppointmentBooking.AppointmentConfirmation.Requests;
using DoctorAppointmentBooking.AppointmentConfirmation.Services;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentBooking.AppointmentConfirmation.Controllers;

public class AppointmentConfirmationController(ConfirmAppointmentService confirmAppointmentService)
{
    [HttpPost("appointment-confirmation")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<bool> BookAppointment([FromBody] BookAppointmentRequest request)
    {
        return await confirmAppointmentService.ConfirmAppointmentAsync(request);
    }
}