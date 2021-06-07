using Application.DataAccess.Abstract.Repository;
using Application.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataAccess.Abstract
{
    /// <summary>
    /// Incoming visitor repository interface.
    /// </summary>
    public interface IIncomingVisitorDal : IRepository<IncomingVisitor, int>
    {

    }
}
