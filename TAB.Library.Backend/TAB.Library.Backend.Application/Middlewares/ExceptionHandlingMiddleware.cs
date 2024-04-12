using TAB.Library.Backend.Core.Exceptions;
using TAB.Library.Backend.Core.Exceptions.Base;

namespace TAB.Library.Backend.Application.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (EntityNotFoundException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (EntityAlreadyExistsException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (RequestValidationException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
            catch (Exception)
            {
                await HandleExceptionAsync(context, new UnrecognizedException());
            }

        }

        private async Task HandleExceptionAsync(HttpContext context, BaseException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)exception.StatusCode;

            ErrorResponse responseModel = new(exception.StatusCode, exception.GetType().Name, exception.Message);
            await context.Response.WriteAsync(responseModel.ToString());
        }
    }
}
