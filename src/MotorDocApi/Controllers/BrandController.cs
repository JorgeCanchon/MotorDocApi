using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorDocApi.Core.Models;
using MotorDocApi.Core.UseCases.Brand;

namespace MotorDocApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandInteractor _brandInteractor;
        public BrandController(IBrandInteractor brandInteractor)
        {
            _brandInteractor = brandInteractor;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Brands> referenceBrand = _brandInteractor.GetBrands();
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