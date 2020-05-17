using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.UseCases.ReferenceBrand;

namespace MotorDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceBrandController : ControllerBase
    {
        private readonly IReferenceBrandInteractor _referenceBrandInteractor;

        public ReferenceBrandController(IReferenceBrandInteractor referenceBrandInteractor)
        {
            _referenceBrandInteractor = referenceBrandInteractor;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<ReferenceBrand> referenceBrand = _referenceBrandInteractor.GetReferenceBrand();
                if (referenceBrand.Any())
                    return Ok(referenceBrand);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [Authorize]
        [HttpGet("{idBrand}")]
        public IActionResult Get(int idBrand)
        {
            try
            {
                IEnumerable<ReferenceBrand> referenceBrand = _referenceBrandInteractor.GetReferenceBrandByBrand(idBrand);
                if (referenceBrand.Any())
                    return Ok(referenceBrand);
                return NoContent();
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}