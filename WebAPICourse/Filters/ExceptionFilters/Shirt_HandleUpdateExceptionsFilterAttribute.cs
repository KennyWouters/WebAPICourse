using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Webapp.Data;

namespace Webapp.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ApplicationDbContext dbContext;

        public Shirt_HandleUpdateExceptionsFilterAttribute(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtId = context.RouteData.Values["id"] as string;
            if (int.TryParse(strShirtId, out int shirtId))
            {
                if (dbContext.Shirts.FirstOrDefault(s => s.ShirtId == shirtId) == null)

                {
                    context.ModelState.AddModelError("ShirtId", "Shirt doesn't exist anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }

            }

        }

    }
}
