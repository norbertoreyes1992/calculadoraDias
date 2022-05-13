using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace calculadoraDias.Helpers
{
    public class HttpHelper<T>
    {
        const string sUrl = "https://newsapi.org/v2/top-headlines?country=mx&page=";
        const string sApikey = "f27c754f2c424e54816312518f3fcf47";
        const string sContent = "X-Api-key";

        HttpClientHandler handler = new HttpClientHandler();

        public async Task<T> obtenerNoticias(int iPagina)
        {
            var vUri = new Uri(sUrl + iPagina);
            var client = new HttpClient(handler);
            client.DefaultRequestHeaders.Add(sContent, sApikey);

            client.BaseAddress = vUri;
            var response =
                await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            var jsonResult =
                await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }
    }
}
