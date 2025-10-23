using Microsoft.AspNetCore.Mvc;
using WebAPICourse.Filters;
using WebAPICourse.Models;
using WebAPICourse.Models.Repositories;

namespace WebAPICourse.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(ShirtRepository.GetAllShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.CreateShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateShirtUpdateFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            try
            {
                ShirtRepository.UpdateShirt(shirt);
            }
            catch
            {
                if (!ShirtRepository.ShirtExists(id)) return NotFound($"Shirt with ID {id} not found.");

                throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleted shirt with ID: {id}";
        }


    }

}
