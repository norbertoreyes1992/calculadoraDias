using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace calculadoraDias.Helpers
{
    public class HttpHelper<T>
    {
        //const string sUrl = "https://gears-calendar-systems.herokuapp.com/api/holidays";
        const string sUrl = "http://172.16.214.55:3000/api/holidays/getHolidas";

        HttpClientHandler handler = new HttpClientHandler();

        public async Task<T> getDays(string sJson)
        {
            var vUri = new Uri(sUrl);
            var client = new HttpClient(handler);

            var data = new StringContent(sJson, Encoding.UTF8, "application/json");

            client.BaseAddress = vUri;
            var response =
                await client.PostAsync(client.BaseAddress, data);

            var jsonResult =
                await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }
    }
}
