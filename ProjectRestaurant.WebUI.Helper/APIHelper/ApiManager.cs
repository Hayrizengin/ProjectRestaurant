using Newtonsoft.Json;
using ProjectRestaurant.WebUI.Helper.Response;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.WebUI.Helper.APIHelper
{
    public class ApiManager: IApiService
    {
        public async Task<ApiResponse<TResponse>> SendRequestAsync<TRequest, TResponse>(ApiRequest<TRequest> request)
        {

            var method = Enum.Parse<Method>(request.Method.ToString(), true);

            var url = "https://localhost:7238" +  request.URL;
            var client = new RestClient(url);
            var restRequest = new RestRequest(url, method);

            if (request.Token is not null)
            {
                restRequest.AddHeader("Authorization", "Bearer " + request.Token);
            }


            if (request.Body is not null)
            {
                restRequest.AddBody(request.Body, "application/json");
            }
            RestResponse restResponse = await client.ExecuteAsync(restRequest);

            var responseObject = JsonConvert.DeserializeObject<ApiResponse<TResponse>>(restResponse.Content);
            responseObject.StatusCode = restResponse.StatusCode;
            return responseObject;
        }
    }
}
