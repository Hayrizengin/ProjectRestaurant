using ProjectRestaurant.Entity.Base;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IGenericService<TRequest,TResponse,TAddRequest>
    {
        Task<ApiResponse<TResponse>>AddAsync(TAddRequest entity);
        Task<ApiResponse<bool>> UpdateAsync(TRequest entity);
        Task<ApiResponse<bool>> DeleteAsync(int id);
        Task<ApiResponse<TResponse>> GetAsync(int id);
        Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(TAddRequest? entity);
    }
}
