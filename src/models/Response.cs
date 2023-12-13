using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class Response<T>
    {
        public T? Result { get; set; }
        public IEnumerable<T>? Results { get; set; }

        public bool IsSuccess { get; set; } = false;
    }
}
