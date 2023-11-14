using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace api_Delovyi_Linii
{
    public class ClientDelovyiLinii
    {
 
        private string _apiKey;
        
        public ClientDelovyiLinii(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<string?> Request(string urlRequest, string jsonRequestData)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(jsonRequestData, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(urlRequest, content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        return response.Content.ReadAsStringAsync().Result;
                    }

                    Console.WriteLine("Error: " + response.StatusCode);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            return null;
        }
        
        public async Task<string?> GetFirstDate(string cityDerival, string mass, string volume)
        {
            const string urlGetFirstDate = "https://api.dellin.ru/v2/request/address/dates.json";
            
            string jsonContent = $"{{\n   \"appkey\":\"{_apiKey}\",\n   \"delivery\":{{\n      \"deliveryType\":{{\n         \"type\":\"auto\"\n      }},\n      \"derival\":{{\n         \"address\":{{\n            " +
                                 $"\"search\":\"{cityDerival}\"\n         }}     \n      }}\n   }},\n   \"cargo\":{{\n      \"weight\":0,\n      \"height\":0,\n      \"width\":0,\n      \"length\":0,\n" +
                                 $"      \"totalVolume\":{volume},\n      \"totalWeight\":{mass}\n   }}\n}}";
           
            string? responce = await Request(urlGetFirstDate, jsonContent);
            
            string pattern = "\"dates\":\\[\"(.*?)\"";
            if (responce != null)
            {
                Match match = Regex.Match(responce, pattern);
                if (match.Success)
                {
                    return match.Groups[1].Value;
                }
            }
            
            return null;
        }

        public async Task<double?> CalculatePrice(string cityArrival, double mass, double volume)
        {
            const string urlCalculator = "https://api.dellin.ru/v2/calculator.json";
            string massStr = mass.ToString(CultureInfo.InvariantCulture);
            string volumeStr = volume.ToString(CultureInfo.InvariantCulture);
            string? firstDate = await GetFirstDate("г. Чайковский, ул. Промышленная, 8/25", massStr, volumeStr);
            if (!cityArrival.Contains(','))
            {
                cityArrival += ", Ленина 1";
            }
            
            string jsonContent =
                $"{{\n   \"appkey\":\"{_apiKey}\",\n   \"delivery\":{{\n      \"deliveryType\":{{\n         \"type\":\"auto\"\n      }},\n      \"arrival\":{{\n         \"variant\":\"address\",\n         \"address\":{{\n            " +
                $"\"search\":\"{cityArrival}\"\n         }},\n        \"time\":{{\n            \"worktimeStart\":\"08:00\",\n            \"worktimeEnd\":\"17:00\"\n         }}\n      }},\n      \"derival\":{{\n        " +
                $"\"produceDate\":\"{firstDate}\",\n         \"variant\":\"address\",\n         \"address\":{{\n            " +
                $"\"search\":\"г. Чайковский, ул. Промышленная, 8/25\"\n         }},\n        \"time\":{{\n            \"worktimeStart\":\"08:00\",\n            \"worktimeEnd\":\"17:00\"\n         }}\n      }}\n   }},\n   " +
                $"\"cargo\":{{\n     \"length\":0,\n      \"width\":0,\n      \"height\":0,\n      " +
                $"\"totalVolume\":{volumeStr},\n      \"totalWeight\":{massStr},\n      \"hazardClass\":0\n   }}\n}}";
            
            string? responce = await Request(urlCalculator, jsonContent);
            
            string pattern = "]},\"price\":(.*?),\"";
            if (responce != null)
            {
                Match match = Regex.Match(responce, pattern);
                if (match.Success)
                {
                    return double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                }
            }
            
            return null;
        }
    }
}
