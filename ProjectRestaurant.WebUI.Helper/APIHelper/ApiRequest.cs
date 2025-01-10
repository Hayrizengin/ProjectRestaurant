using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Helper.APIHelper
{
    public class ApiRequest<TRequest>
    {
        public TRequest? Body { get; set; } = default;
        public string URL { get; set; }
        public HttpMethod Method { get; set; }
        public string? Token { get; set; }
    }
}
