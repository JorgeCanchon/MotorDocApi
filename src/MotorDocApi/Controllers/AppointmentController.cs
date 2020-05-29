using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.UseCases.Appointment;

namespace MotorDocApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {

        private readonly IAppointmentInteractor _appointmentInteractor;

        public AppointmentController(IAppointmentInteractor appointmentRepository)
        {
            _appointmentInteractor = appointmentRepository;
        }

        //[Consumes(MediaTypeNames.Application.Json)]
        [Authorize]
        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                IEnumerable<Appointment> appointments = _appointmentInteractor.GetAppointment();
                if (appointments.Any())
                    return Ok(appointments);
                return NoContent();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Appointment appointment)
        {
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return BadRequest(ModelState);
            }
            long result = _appointmentInteractor.InsertAppointment(appointment);
            if (result == -1 || result == 0)
                return StatusCode(500);
            return Ok(result);
        }
        [Authorize]
        [HttpPost("QualifyAppointment")]
        public IActionResult QualifyAppointment(Maintenancerating maintenancerating)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(maintenancerating);
            }
            long result = _appointmentInteractor.QualifyAppointment(maintenancerating);
            if (result == -1 || result == 0)
                return StatusCode(500);
            return Ok(result);
        }

        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
    }
}