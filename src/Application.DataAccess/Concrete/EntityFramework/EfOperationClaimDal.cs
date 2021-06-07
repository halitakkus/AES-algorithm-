using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Configuration.Context;
using Application.Core.Entities.Concrete;
using Application.DataAccess.Abstract;
using Application.DataAccess.Concrete.EntityFramework.Repository;

namespace Application.DataAccess.Concrete.EntityFramework
{
    class EfOperationClaimDal : EfRepositoryBase<OperationClaim, int>, IOperationClaimDal
    {
        private readonly IApplicationConfigurationContext _asminConfigurationContext;

        public EfOperationClaimDal(IApplicationConfigurationContext asminConfigurationContext) : base(asminConfigurationContext.ConnectionString)
        {

        }
    }
}
