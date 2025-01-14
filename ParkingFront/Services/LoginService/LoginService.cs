using Microsoft.UI.Xaml.Controls;
using ParkingFront.DTO;
using ParkingFront.DTO.Login;
using ParkingFront.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Windows.System;

namespace ParkingFront.Services.LoginService
{
    public class LoginService
    {

        private HttpClient _httpClient;

        public LoginService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5235/api/")
            };

        }

        public async Task<LoginResponse> Login(string _identification, string _password)
        {

            var loginRequest = new LoginRequest
            {
                identification = _identification,
                password = _password
            };

            var content = new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("Login", content);
            // Serializar la solicitud a JSON
            var jsonRequest = JsonSerializer.Serialize(loginRequest);

            // Imprimir la solicitud en la consola
            Console.WriteLine("Solicitud de inicio de sesión:");
            Console.WriteLine(jsonRequest);

            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<LoginResponse>();
                return loginResponse;
            }
            else
            {
                return null;
            }


        }
    }
}
