using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Business.Abstract;
using Application.Core.Entities.Concrete;
using Application.Core.Utilities.Result;
using Application.DataAccess.Abstract;

namespace Application.Business.Concrete
{
    class OperationClaimManager : IOperationClaimManager
    {
        private readonly IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        public async Task<IDataResult<List<OperationClaim>>> GetClaimsAsync()
        {
            var claims = await _operationClaimDal.GetListAsync();
            return new SuccessDataResult<List<OperationClaim>>(claims);
        }
    }
}
