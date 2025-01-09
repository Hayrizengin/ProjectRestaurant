using ProjectRestaurant.Tools.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Exceptions
{
    public class InvalidUserCredentialsException : AppBaseException
    {
        public InvalidUserCredentialsException()
            : base("Geçersiz kullanıcı adı veya şifre.",HttpStatusCode.Unauthorized)
        {
        }

        public InvalidUserCredentialsException(string username)
            : base($"'{username}' kullanıcı adına sahip kullanıcı için geçersiz kimlik bilgileri sağlandı.", HttpStatusCode.Unauthorized)
        {
        }
    }
}
