using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Condominios.API.Responses
{
    public class ApiResponse<T> //where T : class
    {
        public ApiResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        //public bool IsSuccess { get; set; }

        //public string Message { get; set; }

        //public T Result { get; set; }
    }
}
