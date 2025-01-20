using Microsoft.Graphics.DirectX;
using Newtonsoft.Json;
using ParkingFront.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;


namespace ParkingFront.Services.SpacesService
{
    public class SpaceService
    {
        private HttpClient _httpClient;


        public SpaceService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5235/api/")
            };
        }


        public async Task<IEnumerable<Espacio>> GetSpacesApi(int floorNumber)
        {
            var response = await _httpClient.GetAsync($"Space/{floorNumber}");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Espacio>>(content);
        }



       
    }
}
