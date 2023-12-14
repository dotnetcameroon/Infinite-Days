using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{
    public class DatabaseAccessModel(ResultType resultType, object? parameters, string commandText)
    {
        public  ResultType ResultType  => resultType;
        public object? Parameters => parameters;
        public string CommandText => commandText;

    }
    public enum ResultType
    {
        Single = 1,
        Multiple = 2,
        NoResult = 3
    }

}
