using Microsoft.AspNetCore.Mvc;
using WebAPICourse.Filters.ActionFilters;
using WebAPICourse.Filters.ExceptionFilters;
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
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            ShirtRepository.UpdateShirt(shirt);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]

        public IActionResult DeleteShirt(int id)
        {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);
            return Ok(shirt);

        }


    }

}
