using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Common.Error
{
    public class MyExcepton : Exception
    {
        public MyExcepton() { }

        public MyExcepton(string message) : base(message) { }

        public MyExcepton(string message, Exception innerException) : base(message, innerException) { }
    }
}
