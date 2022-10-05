using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardInformationsController : ControllerBase
    {
        ICreditCardInformationService _creditCardInformationService;
        public CreditCardInformationsController(ICreditCardInformationService creditCardInformationService)
        {
            _creditCardInformationService = creditCardInformationService;
        }

        [HttpPost("add")]
        public IActionResult Add(CreditCardInformation creditCardInformation)
        {
            var result=_creditCardInformationService.Add(creditCardInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CreditCardInformation creditCardInformation)
        {
            var result = _creditCardInformationService.Delete(creditCardInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CreditCardInformation creditCardInformation)
        {
            var result = _creditCardInformationService.Update(creditCardInformation);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
