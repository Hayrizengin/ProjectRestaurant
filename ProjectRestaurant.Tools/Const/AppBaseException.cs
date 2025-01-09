using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Const
{
    public abstract class AppBaseException : Exception
    {
        //Middleware'de tüm exceptionları tek tek yazmak yerine tek yerden kontrol etmek için yazıldı.
        public HttpStatusCode StatusCode { get; }

        protected AppBaseException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
            AppContextManager.ResponseStatusCode = statusCode;
        }
    }
}
