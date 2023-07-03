using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.UnitTests.Data
{
    public static class DataJourneyFlight
    {
        public static List<JourneyFlight> GetDataJourneyFlight()
        {

            return new List<JourneyFlight>()
            {
                new JourneyFlight   {
                  JourneyId= 1,
                  FlightId = 1
                },
                 new JourneyFlight   {
                  JourneyId= 1,
                  FlightId = 2
                },
                 new JourneyFlight   {
                  JourneyId= 2,
                  FlightId = 3
                },
                 new JourneyFlight   {
                  JourneyId= 2,
                  FlightId = 4
                },
                 new JourneyFlight   {
                  JourneyId= 2,
                  FlightId = 2
                },
            };
        }
    }

}
