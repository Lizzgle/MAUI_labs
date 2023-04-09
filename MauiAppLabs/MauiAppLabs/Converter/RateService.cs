using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using NbrbAPI.Models;

namespace MauiAppLabs.Converter
{
    public class RateService : IRateService
    {
        private HttpClient client;
        public RateService(HttpClient httpClient)
        {
            client = httpClient;
        }

        public async Task<IEnumerable<Rate>> GetRates(DateTime date)
        {
            var message = new HttpRequestMessage(HttpMethod.Get, client.BaseAddress +
                        "?ondate=" + date.Date.ToString("yyyy-MM-dd") + "&periodicity=0");

            var response = await client.SendAsync(message); //Отправляет HTTP-запрос с указанным запросом

            if (!response.IsSuccessStatusCode) //Возвращает значение, указывающее, завершился ли успешно HTTP-ответ.
                return null;

            return await JsonSerializer.
                            DeserializeAsync<IEnumerable<Rate>>
                                    (response.Content.ReadAsStream());
        }
    }
}
