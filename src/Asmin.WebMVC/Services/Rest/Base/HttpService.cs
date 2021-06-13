using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AES.WebMVC.Services.Rest.Base;
using Application.Core.Configuration.Context;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace app.WebMVC.Services.Rest.Base
{
    public class HttpService : IHttpService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IApplicationConfigurationContext _appConfigurationContext;

        public HttpService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor, IApplicationConfigurationContext appConfigurationContext)
        {
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            _appConfigurationContext = appConfigurationContext;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            var httpClient = _httpClientFactory.CreateClient();

            httpClient.BaseAddress = new Uri(_appConfigurationContext.ApiUrl);

            var responseMessage = await httpClient.GetAsync(url);

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<T> PostAsync<T>(string url, object data)
        {
            var httpClient = _httpClientFactory.CreateClient();


            httpClient.BaseAddress = new Uri(_appConfigurationContext.ApiUrl);

            var httpContent = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");

            var responseMessage = await httpClient.PostAsync(url, httpContent);

            var content = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(content);
        }
    }
}
