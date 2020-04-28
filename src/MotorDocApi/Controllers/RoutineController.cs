using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.UseCases.Routine;

namespace MotorDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoutineController : ControllerBase
    {
        private readonly IRoutineInteractor _routineInteractor;
        public RoutineController(IRoutineInteractor routineInteractor)
        {
            _routineInteractor = routineInteractor;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Routine> routines = _routineInteractor.GetRoutine();
                if (routines.Any())
                    return Ok(routines);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.InnerException.ToString());
            }
        }

        [Authorize]
        [HttpGet("byWorkshop")]
        public IActionResult GetWorkshop(long workshopId)
        {
            try
            {
                IEnumerable<Routine> routines = _routineInteractor.GetRoutinesByWorkshop(workshopId);
                if (routines.Any())
                    return Ok(routines);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.InnerException.ToString());
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(Routine routine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _routineInteractor.InsertRoutine(routine);
            if (result == -1 || result == 0)
                return StatusCode(500);
            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public IActionResult Put(Routine routine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _routineInteractor.UpdateRoutine(routine);
            if (result != EntityState.Modified)
                return StatusCode(500);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(long idRoutine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _routineInteractor.DeleteRoutine(idRoutine);
            if (result != EntityState.Modified)
                return StatusCode(500);
            return Ok();
        }
    }
}