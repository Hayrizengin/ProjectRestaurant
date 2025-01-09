using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Const
{
    public class AppContextManager
    {
        // Middleware içindeki exceptionların içine statusCode'u otomatik şekilde atarız.
        public static HttpStatusCode? ResponseStatusCode
        {
            get
            {
                return (HttpStatusCode?)AppContext.GetData("ResponseStatusCode");
            }

            set
            {
                if (value == null)
                {
                    AppContext.SetData("ResponseStatusCode", HttpStatusCode.InternalServerError);
                }
                else
                {
                    AppContext.SetData("ResponseStatusCode", value);
                }
            }
        }
    }
}
