using Application.Business.Abstract;
using Application.Core.Constants.Messages;
using Application.Core.Utilities.Result;
using Application.DataAccess.Abstract;
using Application.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Business.Concrete
{
    public class IncomingVisitorManager : IIncomingVisitorManager
    {
        private readonly IIncomingVisitorDal _incomingVisitorDal;

        public IncomingVisitorManager(IIncomingVisitorDal incomingVisitorDal)
        {
            _incomingVisitorDal = incomingVisitorDal;
        }

        public async Task<IResult> AddAsync(IncomingVisitor incomingVisitor)
        {
            await _incomingVisitorDal.AddAsync(incomingVisitor);
            return new SuccessResult(ResultMessages.IncomingVisitorAdded);
        }

        public async Task<IDataResult<int>> GetCountAsync()
        {
            var visitorsCount = await _incomingVisitorDal.GetCountAsync();
            return new SuccessDataResult<int>(visitorsCount);
        }
    }
}
