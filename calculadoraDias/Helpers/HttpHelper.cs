using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace calculadoraDias.Helpers
{
    public class HttpHelper<T>
    {
#if PRODUCCION
        const string sUrl = "https://gears-calendar-systems.herokuapp.com/api/holidays";
#elif DEV
        const string sUrl = "http://172.16.214.55:3000/api/holidays/getHolidas";
#endif

        HttpClientHandler handler = new HttpClientHandler();

        /// <summary>
        /// Metodo encargado de obtener los dias festivos
        /// </summary>
        /// <param name="sJson">json con la fecha inicio y fecha fin a buscar</param>
        /// <returns>regresa un objeto con la </returns>
        public async Task<T> getDays(string sJson)
        {
            var vUri = new Uri(sUrl);
            var cliente = new HttpClient(handler);

            var data = new StringContent(sJson, Encoding.UTF8, "application/json");

            cliente.BaseAddress = vUri;
            var response =
                await cliente.PostAsync(cliente.BaseAddress, data);

            var jsonResult =
                await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }
    }
}
