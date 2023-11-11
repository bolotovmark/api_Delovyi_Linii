using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using api_Delovyi_Linii.TemplateJsonClasses;

namespace api_Delovyi_Linii
{
    public class ClientDelovyiLinii
    {
        private string _login;
        private string _password;
        private string _apiKey;
        private string? _sessionToken;
        private HttpClient _httpClient;
        
        
        public ClientDelovyiLinii(string login, string password, string apiKey)
        {
            _login = login;
            _password = password;
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            var t = Task.Run(async () => await Auth());
            t.Wait();
        }

        private async Task Auth()
        {
            const string urlAuth = "https://api.dellin.ru/v3/auth/login.json";

            try
            {
                using (_httpClient)
                {
                
                    RequestAuth requestData = new RequestAuth(_apiKey, _login, _password);
                    string jsonData = JsonSerializer.Serialize(requestData);

                    _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                
                    HttpResponseMessage response = await _httpClient.PostAsync(urlAuth, content);
                    //Console.WriteLine(response);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        //Console.WriteLine(result);
                
                        ResponceAuth? responseDeserialize = JsonSerializer.Deserialize<ResponceAuth>(result);
                        _sessionToken = responseDeserialize?.data.sessionID;
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }

        public async Task<string?> GetFirstDate(string cityDerival, double mass, double volume)
        {
            const string urlGetFirstDate = "https://api.dellin.ru/v2/request/address/dates.json";
           
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    RequestGetDateDerival requestData = new RequestGetDateDerival(_apiKey, 
                        _sessionToken, cityDerival, mass, volume);
                    
                    string jsonData = JsonSerializer.Serialize(requestData);
                    
                    _httpClient.DefaultRequestHeaders.Accept
                        .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                
                    HttpResponseMessage response = await client.PostAsync(urlGetFirstDate, content);
                    //Console.WriteLine(response);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        //Console.WriteLine(result);
                
                        ResponceGetDateDerival? responseDeserialize = JsonSerializer.Deserialize<ResponceGetDateDerival>(result);

                        if (responseDeserialize != null) return responseDeserialize.data.dates[0];
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return null;
        }
        
        public async Task<double?> CalculatePrice(string cityArrival, double mass, double volume)
        {
            const string urlCalculator = "https://api.dellin.ru/v2/calculator.json";
            string? firstDate = await GetFirstDate("г. Чайковский, ул. Промышленная, 8/25", mass, volume);
            
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    RequestCalculatePrice requestData = new RequestCalculatePrice(_apiKey, _sessionToken,
                        cityArrival, "г. Чайковский, ул. Промышленная, 8/25", firstDate, mass, volume);
                    
                    string jsonData = JsonSerializer.Serialize(requestData);
                    Console.WriteLine(jsonData);
                    _httpClient.DefaultRequestHeaders.Accept
                        .Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                
                    HttpResponseMessage response = await client.PostAsync(urlCalculator, content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string result = response.Content.ReadAsStringAsync().Result;
                        
                
                        ResponceCalculatePrice? responseDeserialize = JsonSerializer.Deserialize<ResponceCalculatePrice>(result);
                        if (responseDeserialize != null) return responseDeserialize.data.price;
                    }
                    else
                    {
                        Console.WriteLine("Error: " + response.StatusCode);
                    }
                    
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return null;
        }
        
    }
}
