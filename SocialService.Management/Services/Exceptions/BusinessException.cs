using System;

namespace SocialService.Management.Services.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}
