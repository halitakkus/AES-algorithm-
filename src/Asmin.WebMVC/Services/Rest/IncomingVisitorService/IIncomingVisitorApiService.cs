using Application.Core.Utilities.Result;
using Application.Entities.Concrete;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Rest.IncomingVisitorService
{
    public interface IIncomingVisitorApiService
    {
        Task<Result> AddAsync(IncomingVisitor incomingVisitor);
        Task<DataResult<int>> GetCountAsync();
    }
}
