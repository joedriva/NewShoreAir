using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.Models
{
    public class FligthExternalVm
    {
        public string DepartureStation { get; set; } = string.Empty;
        public string ArrivalStation { get; set; } = string.Empty;
        public string FlightCarrier { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
