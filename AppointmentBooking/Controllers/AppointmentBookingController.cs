using System.Net;
using DoctorAppointmentBooking.AppointmentBooking.Models;
using DoctorAppointmentBooking.AppointmentBooking.Requests;
using DoctorAppointmentBooking.AppointmentBooking.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentBooking.AppointmentBooking.Controllers;

public class AppointmentBookingController(
    ViewDoctorAvailableSlotsUseCase viewDoctorAvailableSlotsUseCase,
    BookAppointmentUseCase bookAppointmentUseCase) : Controller
{
    [HttpGet("{doctorId:Guid}/appointment-booking")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<DoctorSlot>))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<List<DoctorSlot>> ViewDoctorAvailableSlots([FromRoute(Name = "doctorId")] Guid doctorId)
    {
        return await viewDoctorAvailableSlotsUseCase.ViewDoctorAvailableSlots(doctorId);
    }

    [HttpPost("appointment-booking")]
    [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(bool))]
    [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType((int)HttpStatusCode.Forbidden)]
    public async Task<bool> BookAppointment([FromBody] BookAppointmentRequest request)
    {
        var appointment = new Appointment
        {
            Id = new Guid(),
            PatientId = request.PatientId,
            PatientName = request.PatientName,
            SlotId = request.SlotId,
            ReservedAt = request.ReservedAt,
            Status = Status.Booked
        };
        return await bookAppointmentUseCase.BookAppointmentAsync(appointment);
    }
}
