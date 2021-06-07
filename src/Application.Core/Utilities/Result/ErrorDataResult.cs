using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Result
{
    /// <summary>
    /// Error result for unsuccessful method.
    /// </summary>
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data) : base(data, false)
        {

        }

        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
    }
}
