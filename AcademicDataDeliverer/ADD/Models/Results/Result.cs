using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADD.Models.Results
{
    public class Result
    {
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, string errorMessage) : this(success)
        {
            ErrorMessage = errorMessage;
        }
    }
}
