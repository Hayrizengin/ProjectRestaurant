using ProjectRestaurant.Tools.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Exceptions
{
    public class TokenInvalidException : AppBaseException
    {
        public TokenInvalidException() : base("Token Geçersiz",HttpStatusCode.Unauthorized)
        {

        }
    }
}
