using NewShoreAir.Domain.Common;

namespace NewShoreAir.Domain
{
    public class Journey : BaseDomainModel
    {
        public string? Origin { get; set; }
        public string? Destination { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Flight>? Flights { get; set; }
        public virtual ICollection<JourneyFlight>? JourneyFlights { get; set; }

        

    }

}