using ProjectRestaurant.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Business.Abstract
{
    public interface IGenericService<TRequest,TResponse>
    {
        Task<TResponse> AddAsync(TRequest entity);
        Task UpdateAsync(TRequest entity);
        Task DeleteAsync(TRequest entity);
        Task<TResponse> GetAsync(TRequest entity);
        Task<List<TResponse>> GetAllAsync(TRequest entity);
    }
}
