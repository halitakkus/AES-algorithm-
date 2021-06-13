using System.Threading.Tasks;

namespace AES.WebMVC.Services.Rest.Base
{
    public interface IHttpService
    {
        /// <summary>
        /// Get isteklerini atın.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        Task<T> GetAsync<T>(string url);

        /// <summary>
        /// Post isteklerini atın.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<T> PostAsync<T>(string url, object data);
    }
}
