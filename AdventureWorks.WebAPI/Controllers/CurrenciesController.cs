using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data.Repository;
using Adventureworks.Data;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CurrenciesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (_unitOfWork.Currency ==null)
            {
                return NotFound();
            }
            var res= _unitOfWork.Currency.GetAll();
            return Ok(res);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK,Type= typeof(Currency))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetById(string id)
        {
            var currency = _unitOfWork.Currency.GetById(id);

            if (currency == null)
            {
                return NotFound();
            }            
            return Ok(currency);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCurrency (string id, Currency currency)
        {
            if (id !=currency.CurrencyCode)
            {
                return BadRequest();
            }
            _unitOfWork.Currency.Update(currency);
           await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

       [HttpPost]
       public async Task<ActionResult<Currency>> Post (Currency currency)
        {
            if (_unitOfWork.Currency==null)
            {
                return BadRequest("No existe el objeto");

            }
            _unitOfWork.Currency.Add(currency);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction("Post", new { id = currency.CurrencyCode }, currency);
        }

        [HttpDelete("id")]
        public  async Task<IActionResult> Delete (string id)
        {
            try
            {
                var currency = _unitOfWork.Currency.GetFirstOrDefault(
                    filter: t => t.CurrencyCode == id);

                if (currency == null)
                {
                    return NotFound();
                }

                _unitOfWork.Currency.Delete(currency);
                await _unitOfWork.SaveChangesAsync();
                return NoContent();

            }
            catch(DbUpdateException ex)
            {
                return BadRequest("No Se pudo eliminar el registro, existen relaciones " + id  );
            }

            catch (Exception ex)
            {

                return BadRequest("No Se pudo eliminar");
            }
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public bool CheckIfExists(string id)
        {
            return false;
        }




    }
}
