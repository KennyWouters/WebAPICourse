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
        public string GetShirts()
        {
            return "List of shirts";
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        public string CreateShirt([FromBody] Shirt shirt)
        {
            return $"Created shirt with data";
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
