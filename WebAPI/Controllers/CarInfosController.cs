using Businness.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarInfosController : ControllerBase
    {
        ICarInfoDetailService _carInfoDetailService;

        public CarInfosController(ICarInfoDetailService carInfoDetailService)
        {
            _carInfoDetailService = carInfoDetailService;
        }

        [HttpPost("Add")]
        public IActionResult Add(CarInfoDetail car)
        {
            var result = _carInfoDetailService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(CarInfoDetail car)
        {
            var result = _carInfoDetailService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(CarInfoDetail car)
        {
            var result = _carInfoDetailService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _carInfoDetailService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
