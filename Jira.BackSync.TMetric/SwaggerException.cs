using System;
using System.Collections.Generic;

namespace Jira.BackSync.TMetric
{
    public class SwaggerException : Exception
    {
        public string StatusCode { get; }

        public string Response { get; }

        public Dictionary<string, IEnumerable<string>> Headers { get; }

        public SwaggerException(
            string message,
            string statusCode,
            string response,
            Dictionary<string, IEnumerable<string>> headers,
            Exception innerException)
            : base(message, innerException)
        {
            StatusCode = statusCode;
            Response = response;
            Headers = headers;
        }

        public override string ToString()
        {
            return $"HTTP Response: \n\n{Response}\n\n{base.ToString()}";
        }
    }

    public class SwaggerException<TResult> : SwaggerException
    {
        public TResult Result { get; }

        public SwaggerException(
            string message,
            string statusCode,
            string response,
            Dictionary<string, IEnumerable<string>> headers,
            TResult result,
            Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }
}