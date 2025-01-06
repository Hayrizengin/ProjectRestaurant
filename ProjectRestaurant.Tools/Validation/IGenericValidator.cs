using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Validation
{
    public interface IGenericValidator
    {
        Task ValidateAsync<T>(T entity, Type type = null);
    }
}
