using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundingSouqExercise.Common
{
    public class ResultWrapper<T>
    {
        public ResultCodeEnum Status { get; set; }
        public T Value { get; set; }
    }
}
