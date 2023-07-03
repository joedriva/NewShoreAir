using MediatR;
using NewShoreAir.Application.Models;


namespace NewShoreAir.Application.Features.Journeys.Queries.GetJourneyByOriginDestination
{
    public class JourneyByOriginDestinationQuery : IRequest<List<JourneyVm>>
    {
        public string Origin { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public int? NumberMaxFlight { get; set; }
    }
}
