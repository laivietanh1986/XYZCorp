using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XYZCorp.Utility
{
    public class CommonResult
    {
        public ResultValue Result { get; set; }
        public object Data { get; set; }
        public string Message { get; set; }
    }
}