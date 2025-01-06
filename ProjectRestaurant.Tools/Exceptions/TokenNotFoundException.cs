using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Exceptions
{
    public class TokenNotFoundException : Exception
    {
        public TokenNotFoundException() : base("Token Bilgisi Gelmedi")
        {

        }
    }
}
