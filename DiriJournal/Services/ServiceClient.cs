namespace DiriJournal.Services
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

        public async Task<string> PutClientMethod(string serviceURL, object obj)
        {
            string retrunString = null;
            HttpClient client = new HttpClient();

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
