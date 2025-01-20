using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingFront.DTO
{
    public class Espacio
    {
        public int ID { get; set; }
        public int Piso { get; set; }
        public string Zona { get; set; }
        public string NumeroEspacio { get; set; }
        public string Estado { get; set; }


        public string getSpace()
        {
            return Zona + " " + NumeroEspacio;
        }
    }
}
