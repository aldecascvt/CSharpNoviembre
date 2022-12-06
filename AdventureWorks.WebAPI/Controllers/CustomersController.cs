using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AdventureWorks.Data;
using AdventureWorks.Data.Repository;
using Adventureworks.Data;

namespace AdventureWorks.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            if (_unitOfWork.Customer ==null)
            {
                return NotFound();
            }
            var res= _unitOfWork.Customer.GetAll();
            return Ok(res);
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK,Type= typeof(Customer))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetById(int id)
        {
            var Customer = _unitOfWork.Customer.GetById(id);

            if (Customer == null)
            {
                return NotFound();
            }            
            return Ok(Customer);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateCustomer (int id, Customer customer)
        {
            if (id !=customer.CustomerId)
            {
                return BadRequest();
            }
            _unitOfWork.Customer.Update(customer);
           await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }
        [HttpPost]
       public async Task<ActionResult<Customer>> Post (Customer customer)
        {
            if (_unitOfWork.Customer==null)
            {
                return Problem("No existe el objeto");

            }
            _unitOfWork.Customer.Add(customer);
            await _unitOfWork.SaveChangesAsync();
            return CreatedAtAction("Post", new { id = customer.CustomerId }, customer);
        }
        [HttpDelete("id")]
        public  async Task<IActionResult> Delete (int id)
        {
            var customer = _unitOfWork.Customer.GetById(id);

            if (customer == null)
            {
                return NotFound();
            }
            _unitOfWork.Customer.Delete( (Customer)customer);
            await _unitOfWork.SaveChangesAsync();
            return NoContent();
        }

    }
}
