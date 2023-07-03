using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.Models
{
    public class FlightVm
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string FlightNumber { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string TransportName { get; set; } = string.Empty;
        public int? TransportId { get; set; }
    }
}
