using Newtonsoft.Json;
using System.Net;
using ExceptionContext = Microsoft.AspNetCore.Mvc.Filters.ExceptionContext;
using IExceptionFilter = Microsoft.AspNetCore.Mvc.Filters.IExceptionFilter;

namespace ADWMAPI.Filters
{
    public class GlobalExceptionFilter : Attribute, IExceptionFilter
    {
        #region Private readonly
        private readonly ILogger<GlobalExceptionFilter> _logger;
        private readonly IServiceProvider _serviceProvider;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="GlobalExceptionFilter"/> class.
        /// </summary>
        /// <param name="logger">The logger</param>
        /// <param name="configuration">The configuration</param>
        /// <param name="localizedResourceProviderProvider">The application resource provider</param>
        public GlobalExceptionFilter(ILogger<GlobalExceptionFilter> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        /// <summary> Called after an action has thrown an <see cref="T:System.Exception" /> </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ExceptionContext"/></param>
        public void OnException(ExceptionContext context)
        {
            var httpContextAccessor = _serviceProvider.GetService<IHttpContextAccessor>();
            HttpStatusCode statusCode = (context.Exception as WebException != null &&
                         ((HttpWebResponse)(context.Exception as WebException).Response) != null) ?
                          ((HttpWebResponse)(context.Exception as WebException).Response).StatusCode
                          : GetErrorCode(context.Exception.GetType());

            var queryString = httpContextAccessor.HttpContext.Request.QueryString.HasValue
               ? httpContextAccessor.HttpContext.Request.QueryString.Value.ToString()
               : string.Empty;

            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";
            var result = JsonConvert.SerializeObject(
                new
                {
                    message = context.Exception.Message,
                    errorCode = statusCode,
                    Instance = $"{httpContextAccessor.HttpContext.Request.Path}{queryString}",
                });

            #region Logging  
            _logger.LogError($"ExceptionMessage:{context.Exception.Message},Exception:{context.Exception},InnerException:{(context.Exception.InnerException != null ? context.Exception.InnerException.Message : string.Empty)},ErrorCode:{(int)statusCode},Stacktrace:{context.Exception.StackTrace}");
            #endregion Logging  

            response.ContentLength = result.Length;
            response.WriteAsync(result);
        }

        /// <summary>  
        /// This method will return the status code based on the exception type.  
        /// </summary>  
        /// <param name="exceptionType"></param>  
        /// <returns>HttpStatusCode</returns>  
        private HttpStatusCode GetErrorCode(Type exceptionType)
        {
            ExceptionType tryParseResult;
            if (Enum.TryParse<ExceptionType>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case ExceptionType.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case ExceptionType.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case ExceptionType.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case ExceptionType.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case ExceptionType.ResourceNotFoundException:
                        return HttpStatusCode.NotFound;

                    case ExceptionType.InvalidInputException:
                        return HttpStatusCode.BadRequest;

                    case ExceptionType.DuplicateResourceException:
                        return HttpStatusCode.Conflict;

                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
    public enum ExceptionType
    {
        NullReferenceException = 1,
        UnauthorizedAccessException = 2,
        InvalidOperationException = 3,
        TimeoutException = 4,
        DuplicateResourceException = 5,
        InvalidInputException = 6,
        ResourceNotFoundException = 7
    }




























}

