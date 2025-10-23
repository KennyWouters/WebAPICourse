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
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            if (shirt == null) return BadRequest();

            var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Gender, shirt.Size);

            if (existingShirt != null) return BadRequest();


            ShirtRepository.CreateShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }

        [HttpPut("{id}")]
        public string UpdateShirt(int id, string shirtData)
        {
            return $"Updated shirt with ID: {id} to data: {shirtData}";
        }

        [HttpDelete("{id}")]
        public string DeleteShirt(int id)
        {
            return $"Deleted shirt with ID: {id}";
        }


    }

}
