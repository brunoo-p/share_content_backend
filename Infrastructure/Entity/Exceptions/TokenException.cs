using Infrastructure.Entity.Request.LinkedinPost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Exceptions
{
    public class TokenException : Exception
    {
        public override string Message { get; } = "Invalid Token, need refresh";
        public HttpStatusCode statusCode { get; } = HttpStatusCode.BadRequest;
        public string urlRefresh { get; private set; }

    }
}
