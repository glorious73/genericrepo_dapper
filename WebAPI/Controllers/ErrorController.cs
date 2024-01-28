using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepo_Dapper.Controllers;

[AllowAnonymous]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorController : Controller
{
    [Route("Error")]
    public IActionResult Error()
    {
        // exception
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var exception = context?.Error;
        // code
        var code = (exception is InvalidOperationException) ? 400 : 500;
        // response
        return StatusCode(code, new { message = exception?.Message + ((exception?.InnerException != null) ? exception.InnerException.Message : "") });
    }
}