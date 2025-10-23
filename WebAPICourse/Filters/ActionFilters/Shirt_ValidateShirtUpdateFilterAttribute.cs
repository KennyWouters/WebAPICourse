using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebAPICourse.Models;

namespace WebAPICourse.Filters.ActionFilters
{
    public class Shirt_ValidateShirtUpdateFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var id = context.ActionArguments["id"] as int?;
            var shirt = context.ActionArguments["shirt"] as Shirt;


            if (id.HasValue && shirt != null && id != shirt.ShirtId)
            {
                context.ModelState.AddModelError("ShirtId", "ShirtId is not the same as id.");
                var problemDetails = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest
                };
                context.Result = new BadRequestObjectResult(problemDetails);

            }

        }


    }
}
