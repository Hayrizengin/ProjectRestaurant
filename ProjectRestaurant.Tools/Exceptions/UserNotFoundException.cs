using ProjectRestaurant.Tools.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Exceptions
{
    public class UserNotFoundException : AppBaseException
    {
        public UserNotFoundException(string email)
            : base($"'{email}'e sahip kullanıcı bulunamadı.",HttpStatusCode.NotFound)
        {
        }
    }
}
