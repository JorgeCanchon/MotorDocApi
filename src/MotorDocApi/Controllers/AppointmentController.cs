using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorDocApi.Core.Entities;
using MotorDocApi.Core.UseCases.Appointment;

namespace MotorDocApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentInteractor _appointmentRepository;

        public AppointmentController(IAppointmentInteractor appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        //[Consumes(MediaTypeNames.Application.Json)]
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Get() 
        {
            try
            {
                IEnumerable<Appointment> appointments = _appointmentRepository.GetAppointment();
                if (appointments.Any())
                    return Ok(_appointmentRepository.GetAppointment());
                return NoContent();
            }
            catch (Exception)
            {
                return Problem();
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post()
        {
            return BadRequest();
        }

        [HttpGet("version")]
        public string Version()
        {
            return "Version 1.0.0";
        }
    }
}