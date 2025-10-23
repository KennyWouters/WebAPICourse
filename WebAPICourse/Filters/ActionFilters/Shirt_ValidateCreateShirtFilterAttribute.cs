using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPICourse.Models;
using WebAPICourse.Models.Repositories;


namespace WebAPICourse.Filters.ActionFilters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirt = context.ActionArguments["shirt"] as Shirt;
            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt object is null.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);
            }
            else
            {
                var existingShirt = ShirtRepository.GetShirtByProperties(shirt.Brand, shirt.Color, shirt.Gender, shirt.Size);
                if (existingShirt != null)
                {

                    context.ModelState.AddModelError("Shirt", "A shirt with the same brand, color , gender, and size already exists.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status409Conflict
                    };
                    context.Result = new ObjectResult(problemDetails);

                }
            }
        }
    }
}
