using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;

namespace Application.Business.Abstract
{
    public interface IOperationClaimManager
    {
        /// <summary>
        /// Returns all claims.
        /// </summary>
        /// <returns></returns>
        Task<IDataResult<List<OperationClaim>>> GetClaimsAsync();
    }
}
