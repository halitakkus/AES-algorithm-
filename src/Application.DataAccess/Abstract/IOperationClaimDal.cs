using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Entities.Concrete;
using Application.DataAccess.Abstract.Repository;

namespace Application.DataAccess.Abstract
{
    public interface IOperationClaimDal : IRepository<OperationClaim, int>
    {
    }
}
