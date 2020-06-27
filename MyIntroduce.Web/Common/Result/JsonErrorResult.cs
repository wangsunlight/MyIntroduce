using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyIntroduce.Web.Common.Result
{
    public class JsonErrorResult
    {
        public string Message { get; set; }

        public string DeveloperMessage { get; set; }
    }
}
