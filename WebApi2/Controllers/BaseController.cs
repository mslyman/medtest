using AutoMapper;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2;

namespace WebApi.Controllers
{
    [ServiceFilter(typeof(ValidateModelAttribute))] // Using custom validation, ServiceFilter is to add logger to attribute
    [ApiController] // Auto-valudation (https://docs.microsoft.com/ru-ru/aspnet/core/web-api/?view=aspnetcore-3.1) - must be disabled in Startup (SuppressModelStateInvalidFilter = true)
    public class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly ILoggerManager _logger;

        public BaseController(IMapper mapper, ILoggerManager logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }


    public class HttpStatusActionResult : IActionResult
    {
        private readonly int status;
        private readonly object data;

        public HttpStatusActionResult(int status, object data = null)
        {
            this.status = status;
            this.data = data;
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(data)
            {
                StatusCode = status                    // StatusCodes.Status200OK
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
}
