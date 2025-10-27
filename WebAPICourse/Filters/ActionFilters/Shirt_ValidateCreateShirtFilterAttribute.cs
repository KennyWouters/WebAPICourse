using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Webapp.Data;
using Webapp.Models;


namespace Webapp.Filters.ActionFilters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext dbContext;

        public Shirt_ValidateCreateShirtFilterAttribute(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

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
                var existingShirt = dbContext.Shirts.FirstOrDefault(x =>
                !string.IsNullOrWhiteSpace(shirt.Brand) &&
                !string.IsNullOrWhiteSpace(x.Brand) &&
                x.Brand.ToLower() == shirt.Brand.ToLower() &&
                !string.IsNullOrWhiteSpace(shirt.Gender) &&
                !string.IsNullOrWhiteSpace(x.Gender) &&
                x.Gender.ToLower() == shirt.Gender.ToLower() &&
                !string.IsNullOrWhiteSpace(shirt.Color) &&
                !string.IsNullOrWhiteSpace(x.Color) &&
                x.Color.ToLower() == shirt.Color.ToLower() &&
                shirt.Size.HasValue &&
                x.Size.HasValue &&
                shirt.Size.Value == x.Size.Value
                );
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
