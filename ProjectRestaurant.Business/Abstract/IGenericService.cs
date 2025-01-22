using ProjectRestaurant.Entity.Base;
using ProjectRestaurant.Tools.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IGenericService<TRequest,TResponse,TUpdateRequest>
    {
        Task<ApiResponse<TResponse>>AddAsync(TRequest entity);
        Task<ApiResponse<bool>> UpdateAsync(TUpdateRequest entity);
        Task<ApiResponse<bool>> DeleteAsync(TUpdateRequest entity);
        Task<ApiResponse<TResponse>> GetAsync(int id);
        Task<ApiResponse<IEnumerable<TResponse>>> GetAllAsync(TRequest? entity);
    }
}
