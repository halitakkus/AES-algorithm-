using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Result
{
    /// <summary>
    /// IDataResult provides use data with IResult.
    /// </summary>
    /// <typeparam name="T">Return data type.</typeparam>
    public interface IDataResult<T> : IResult
    {
        /// <summary>
        /// Return data.
        /// </summary>
        T Data { get; set; }
    }
}
