namespace Shared.WebClientService
{
    public class ServiceClient
    {
        public async Task<string> clientMethod(string serviceURL)
        {
            string retrunString = null;
            HttpClient client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(serviceURL),
                Headers = { { "x-api-key", "a706c3ac258e49a0b195821ff9f054e8" } }                
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.SendAsync(request))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    try
                    {
                        retrunString = apiResponse;
                    }
                    catch (Exception ex)
                    {
                        retrunString = null;
                    }
                }
            }
            return retrunString;
        }

        public async Task<string> PutClientMethod(string serviceURL, Object obj)
        {
            string retrunString = null;
            HttpClient client = new HttpClient();
            //var request = new HttpRequestMessage
            //{
            //    Method = HttpMethod.Post,
            //    RequestUri = new Uri(serviceURL),
            //};

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsync(serviceURL, (HttpContent?)obj))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync(); ;
                    try
                    {
                        retrunString = apiResponse;
                    }
                    catch (Exception ex)
                    {
                        retrunString = null;
                    }
                }


            }
            return retrunString;
        }
    }
}
