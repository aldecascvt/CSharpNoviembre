using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Repository;
using Adventureworks.Data;

namespace AdventureWorks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyRatesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public CurrencyRatesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            if (_unitOfWork.CurrencyRate == null)
            {
                return NotFound();
            }
            var res = _unitOfWork.CurrencyRate.GetAll();
            return Ok(res);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CurrencyRate))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetById(int id)
        {
            var currencyRate = _unitOfWork.CurrencyRate.GetById(id);

            if (currencyRate == null)
            {
                return NotFound();
            }
            return Ok(currencyRate);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCurrencyRate(int id, CurrencyRate currencyRate)
        {
            if (id != currencyRate.CurrencyRateId)
            {
                return BadRequest();
            }
            _unitOfWork.CurrencyRate.Update(currencyRate);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CurrencyRate>> Post(CurrencyRate currencyRate)
        {
            if (_unitOfWork.CurrencyRate == null)
            {
                return BadRequest("No existe el objeto");

            }
            _unitOfWork.CurrencyRate.Add(currencyRate);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction("Post", new { id = currencyRate.CurrencyRateId }, currencyRate);
        }

        [HttpDelete("~/BorrarTasasPorId{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                var currencyRate = _unitOfWork.CurrencyRate.GetFirstOrDefault(
                    filter: t => t.CurrencyRateId == id);

                if (currencyRate== null)
                {
                    return NotFound();
                }

                _unitOfWork.CurrencyRate.Delete(currencyRate);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();

            }
            catch (Exception ex)
            {

                return BadRequest("No Se pudo eliminar");
            }
        }

    }
}