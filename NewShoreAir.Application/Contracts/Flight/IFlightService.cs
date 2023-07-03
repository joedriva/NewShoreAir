using NewShoreAir.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.Contracts.Flight
{
    public interface IFlightService
    {
        Task<JourneyResponse> GetJourney(JourneyRequest request);
        Task<List<FligthExternalVm>> GetFligths();
        Task<List<JourneyVm>> GetCalculateJourney(JourneyRequest request);
        List<FlightVm> GetFlightRoute(JourneyRequest request, List<FlightVm> flightRoute, List<FligthExternalVm> fligths, out List<List<FlightVm>> listFlightRoute);
    }
        
}
