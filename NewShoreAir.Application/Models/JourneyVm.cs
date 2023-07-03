namespace NewShoreAir.Application.Models
{
    public class JourneyVm
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<FlightVm>? Flights { get; set; }
    }
}
