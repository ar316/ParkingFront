using ParkingFront.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.DTO.Login
{
    public class LoginResponse
    {
        public string token { get; set; }
        public string message { get; set; }
        public ClientDTO user { get; set; }
    }
}
