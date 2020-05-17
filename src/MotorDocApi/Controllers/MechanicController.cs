using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.UseCases.Mechanic;

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
    }
}