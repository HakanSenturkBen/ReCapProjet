using Businness.Abstract;
using Entities.Concrete;
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
    public class PaymentsController : ControllerBase
    {
        IBankPaymentService _bankPaymentDal;

        public PaymentsController(IBankPaymentService bankPaymentDal)
        {
            _bankPaymentDal = bankPaymentDal;
        }

        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            var result = _bankPaymentDal.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Add")]
        public IActionResult Add(BankPaymentService bankPayment)
        {
            var result = _bankPaymentDal.Add(bankPayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _bankPaymentDal.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(BankPaymentService bankPayment)
        {
            var result = _bankPaymentDal.Delete(bankPayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("Updete")]
        public IActionResult Update(BankPaymentService bankPayment)
        {
            var result = _bankPaymentDal.Update(bankPayment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
