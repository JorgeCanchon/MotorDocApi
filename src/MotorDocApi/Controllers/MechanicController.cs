using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.UseCases.Mechanic;
using Microsoft.EntityFrameworkCore;

namespace MotorDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MechanicController : ControllerBase
    {
        private readonly IMechanicInteractor _mechanicInteractor;

        public MechanicController(IMechanicInteractor mechanicInteractor)
        {
            _mechanicInteractor = mechanicInteractor ?? throw new ArgumentNullException(nameof(mechanicInteractor));
        }

        [Authorize]
        [HttpGet("{workshopId}/{vehicleId}")]
        public IActionResult GetTreatingMechanic(long workshopId, long vehicleId)
        {
            try
            {
                IEnumerable<Mechanics> mechanics = _mechanicInteractor.GetTreatingMechanic(workshopId, vehicleId);
                if (mechanics.Any())
                    return Ok(mechanics);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Authorize]
        [HttpPut("{idAppointment}")]
        public IActionResult ManageAppointment(long idAppointment, Maintenanceroutine maintenanceroutine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _mechanicInteractor.ManageAppointment(maintenanceroutine, idAppointment);
            if (result != EntityState.Modified)
                return StatusCode(500);
            return Ok();
        }
    }
}