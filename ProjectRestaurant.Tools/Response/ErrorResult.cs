using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRestaurant.Tools.Response
{
    public class ErrorResult
    {
        public List<string> Errors { get; set; }

        public ErrorResult(List<string> errors)
        {
            Errors = errors;
        }

        public static ErrorResult Error(List<string> errors = null)
        {
            return new ErrorResult(errors ?? new List<string>());
        }
    }
}
