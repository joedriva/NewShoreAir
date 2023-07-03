using AutoFixture;
using NewShoreAir.Application.UnitTests.Data;
using NewShoreAir.Domain;
using NewShoreAir.Infrastructure.Persistence;

namespace NewShoreAir.Application.UnitTests.Mocks
{
    public static class MockAsyncRepository
    {
        public static void AddDataJourney(NewShoreAirDbContext NewShoreAirDbContextFake)
        {

            List<Transport> dataTransport = DataTransport.GetDataTransport();
            List<Flight> dataFlight = DataFligth.GetDataFligths();
            List<Journey> dataJourney = DataJourney.GetDataJourney();
            List<JourneyFlight> dataJourneyFlight = DataJourneyFlight.GetDataJourneyFlight();

           

            NewShoreAirDbContextFake.Transport!.AddRange(dataTransport);
            NewShoreAirDbContextFake.Flight!.AddRange(dataFlight);
            NewShoreAirDbContextFake.Journey!.AddRange(dataJourney);
            NewShoreAirDbContextFake.JourneyFlights!.AddRange(dataJourneyFlight);
            NewShoreAirDbContextFake.SaveChanges();

        }
    }
}
