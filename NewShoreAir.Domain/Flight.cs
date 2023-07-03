using NewShoreAir.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Domain
{
    public class Flight : BaseDomainModel
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public string? FlightNumber { get; set; }
        public decimal Price { get; set; }
        public int TransportId { get; set; }
        public Transport? Transport { get; set; }
        public virtual ICollection<Journey>? Journeys { get; set; }
        public virtual ICollection<JourneyFlight>? JourneyFlights { get; set; }

    }
}
