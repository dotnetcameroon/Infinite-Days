using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class DatabaseAccessModel()
    {
        public ResultType ResultType { get; init; } 
        public object Parameters { get; init; } 
        public string CommandText { get; init; } 
    }
    public enum ResultType
    {
        Single = 1,
        Multiple = 2,
        NoResult = 3
    }

}
