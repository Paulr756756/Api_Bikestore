using System.Net;

namespace API_PaulBikeStore.Utilities
{
    public static class CustomActionResponse
    {

        public static ActionResponse<T> CreateErrorResponse<T>(HttpStatusCode httpStatusCode, List<BusinessException> errorDetails, string message = "")
        {
            return new ActionResponse<T>()
            {
                HttpStatusCode = httpStatusCode,
                ApplicationErrors = errorDetails,
                ApplicationMessage = message,
            };
        }

        public static ActionResponse<T> CreateActionResponse<T>(HttpStatusCode httpStatusCode, T responseObject, string? message =null, List<BusinessException> businessExceptions = null)
        {
            return new ActionResponse<T>()
            {
                ResponseObject = responseObject,
                HttpStatusCode = httpStatusCode,
                ApplicationErrors = businessExceptions,
                ApplicationMessage = message,

            };
        }
    }


    public class BusinessException
    {
        public int Code { get; set; }
        public string? Message { get; set; }
    }

    public class ActionResponse<T>
    {
        public string? ApplicationMessage { get; set; }
        public T? ResponseObject { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public IEnumerable<BusinessException>? ApplicationErrors { get; set; }
    }
}
