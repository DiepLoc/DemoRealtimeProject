using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using winform_client.Models;

namespace winform_client.Api
{
    public class DeviceApi
    {
        private HttpClient client;

        public DeviceApi()
        {
            client = HttpClientApi.GetIntance();
        }

        public async Task<string> GetStringAsync(string url = "devices")
        {
            return await client.GetStringAsync(url);
        }

        public async Task PostAsJsonAsync(Device device)
        {
            var response = await client.PostAsJsonAsync("devices", device);
            if (!response.IsSuccessStatusCode) await checkError(response);
        }

        public async Task DeleteAsync(long id)
        {
            var response = await client.DeleteAsync($"devices/{id}");
            if (!response.IsSuccessStatusCode) await checkError(response);
        }

        public async Task PutAsJsonAsync(long id, Device device)
        {
            device.Id = id;
            var response = await client.PutAsJsonAsync($"devices/{id}", device);
            if (!response.IsSuccessStatusCode) await checkError(response);
        }
        private async Task checkError(HttpResponseMessage response)
        {
            var content = await response.Content.ReadAsAsync<dynamic>();
            var message = content.message.ToObject<string>();
            throw new Exception(message);
        }
    }
}
