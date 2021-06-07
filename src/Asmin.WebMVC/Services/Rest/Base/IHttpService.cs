using System.Threading.Tasks;

namespace AES.WebMVC.Services.Rest.Base
{
    public interface IHttpService
    {
        Task<T> GetAsync<T>(string url);
        Task<T> PostAsync<T>(string url, object data);
    }
}
