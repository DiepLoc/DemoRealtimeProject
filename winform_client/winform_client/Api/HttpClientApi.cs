using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace winform_client.Api
{
    class HttpClientApi : HttpClient
    {
        private static HttpClientApi client = null;
        public static HttpClientApi GetIntance()
        {
            if (client == null) client = new HttpClientApi();
            return client;
        }

        private HttpClientApi() : base()
        {
            BaseAddress = new Uri(@"https://localhost:44318/api/");
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue(@"application/json"));
        }

    }
}
