using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Utilities.Result
{
    /// <summary>
    /// IResult provides base information for method status.
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Check method done successfully.
        /// </summary>
        bool IsSuccess { get; set; }
        /// <summary>
        /// Result message.
        /// </summary>
        string Message { get; set; }
    }
}
