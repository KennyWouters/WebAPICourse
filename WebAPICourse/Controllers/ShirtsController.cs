using Microsoft.AspNetCore.Mvc;
using WebAPICourse.Models;

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
        public string GetShirtById(int id)
        {
            return $"Shirt with ID: {id}";
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
