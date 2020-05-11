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
        [HttpGet("treatingMechanic/{workshopId}/{vehicleId}")]
        public IActionResult GetWorkshop(long workshopId, long vehicleId)
        {
            try
            {
                IEnumerable<Mechanics> routines = _mechanicInteractor.GetTreatingMechanic(workshopId, vehicleId);
                if (routines.Any())
                    return Ok(routines);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}