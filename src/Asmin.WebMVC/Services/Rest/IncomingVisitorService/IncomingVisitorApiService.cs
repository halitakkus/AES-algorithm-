using AES.WebMVC.Services.Rest.Base;
using Application.Core.Utilities.Result;
using Application.Entities.Concrete;
using System.Threading.Tasks;

namespace Asmin.WebMVC.Services.Rest.IncomingVisitorService
{
    public class IncomingVisitorApiService : IIncomingVisitorApiService
    {
        private readonly IHttpService _httpService;

        public IncomingVisitorApiService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public Task<Result> AddAsync(IncomingVisitor incomingVisitor)
        {
            return _httpService.PostAsync<Result>("/incomingvisitors", incomingVisitor);
        }

        public Task<DataResult<int>> GetCountAsync()
        {
            return _httpService.GetAsync<DataResult<int>>("/incomingvisitors/count");
        }
    }
}
