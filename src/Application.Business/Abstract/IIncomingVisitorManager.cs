using Application.Core.Utilities.Result;
using Application.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Abstract
{
    public interface IIncomingVisitorManager
    {
        Task<IResult> AddAsync(IncomingVisitor incomingVisitor);
        Task<IDataResult<int>> GetCountAsync();
    }
}
