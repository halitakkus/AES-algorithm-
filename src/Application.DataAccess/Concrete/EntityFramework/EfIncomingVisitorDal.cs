using Application.DataAccess.Abstract;
using Application.DataAccess.Concrete.EntityFramework.Context;
using Application.DataAccess.Concrete.EntityFramework.Repository;
using Application.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Application.Core.Configuration.Context;

namespace Application.DataAccess.Concrete.EntityFramework
{
    public class EfIncomingVisitorDal : EfRepositoryBase<IncomingVisitor, int>, IIncomingVisitorDal
    {
        private readonly IApplicationConfigurationContext _asminConfigurationContext;

        public EfIncomingVisitorDal(IApplicationConfigurationContext asminConfigurationContext) : base(asminConfigurationContext.ConnectionString)
        {
            _asminConfigurationContext = asminConfigurationContext;
        }
    }
}
