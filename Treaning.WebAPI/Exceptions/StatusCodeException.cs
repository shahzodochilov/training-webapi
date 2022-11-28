using System.Net;

namespace Treaning.WebAPI.Exceptions
{
    public class StatusCodeException : Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public StatusCodeException(HttpStatusCode statuscode, string message)
            : base(message)
        {
            this.StatusCode = statuscode;
        }
    }
}
