using ProjectRestaurant.WebUI.Helper.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Helper.APIHelper
{
    public interface IApiService
    {
        Task<ApiResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(ApiRequest<TRequest> request);
    }
}
