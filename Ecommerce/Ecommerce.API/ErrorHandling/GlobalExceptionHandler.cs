using Ecommerce.API.Application.Exceptions;
using Ecommerce.API.Application.Wrappers;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace Ecommerce.API.ErrorHandling;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, 
        Exception exception, 
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Exception occurred: {Message}", exception.Message);

        var response = httpContext.Response;
 
        // If only development mode
        var message = exception.Message;
        var serviceResponse = new ServiceResponse<string>(string.Empty, message, false, response.StatusCode)
        {
            SystemMessage = exception.Message
        };

        switch (exception)
        {
            case ApiException:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                break;
            case ValidationException e:
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                serviceResponse.Errors = e.Errors;
                break;
            case KeyNotFoundException:
                response.StatusCode = (int)HttpStatusCode.NotFound;
                break;
            default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                break;
        }

        await response.WriteAsJsonAsync(serviceResponse, cancellationToken: cancellationToken);

        return true;
    }
}