using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace WebApi2
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        private readonly ILoggerManager _logger;

        public ValidateModelAttribute(ILoggerManager logger)
        {
            _logger = logger;
        }

        // Before controller action executing
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var details = new ValidationProblemDetails(context.ModelState);
                //_logger.LogError(JsonConvert.SerializeObject(details));
                context.Result = new BadRequestObjectResult(details);
            }
        }

    }
}
