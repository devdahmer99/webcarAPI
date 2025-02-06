using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using webcarsAPI.Comunicacao.Responses.Errors;
using webcarsAPI.Exception;
using webcarsAPI.Exception.ExceptionBase;

namespace webcarsAPI.API.Filtros
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
           if(context.Exception is webCarsException)
            {
                HandleProjectException(context);
            } else
            {
                ThrowUnknowError(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {
            var webCarsException = (webCarsException)context.Exception;
            var errorResponse = new ResponseErrors(webCarsException.getErrors());
            context.HttpContext.Response.StatusCode = webCarsException.StatusCode;
            context.Result = new ObjectResult(webCarsException);
        }

        private void ThrowUnknowError(ExceptionContext context)
        {
            var errorResponse = new ResponseErrors(ResourceErrorMessages.UNKNOW_ERROR);
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
