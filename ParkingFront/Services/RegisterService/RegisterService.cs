using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ParkingFront.Services.RegisterService
{
    public class RegisterService
    {
        private HttpClient _httpClient;

        public RegisterService() {
            {
                _httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:5235/api/") 
                };
            }
        }

        public async Task<Boolean> RegisterUserAsync(string identification, string name , string phone, string email, string password)
        {
            var user = new
            {
                identification = identification,
                name = name,
                phone = phone,
                email = email,
                password = password
            };

            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Client", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var error = await response.Content.ReadAsStringAsync();
                return false;
            }
        }
    }
}
