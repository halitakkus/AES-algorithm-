using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Result
{
    /// <summary>
    /// Error result for unsuccessful method.
    /// </summary>
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {

        }

        public ErrorResult(string message) : base(false, message)
        {

        }
    }
}
