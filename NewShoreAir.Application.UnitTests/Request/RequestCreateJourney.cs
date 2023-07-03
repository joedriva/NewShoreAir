using NewShoreAir.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.UnitTests.Request
{
    public static class RequestCreateJourney
    {
        public static List<JourneyVm> GetData()
        {

            return new List<JourneyVm>()
            {
                new JourneyVm
                {
                    Origin= "mzl",
                    Destination= "bcn",
                    Price= 700,
                    Flights = new List<FlightVm>
                    {
                        new FlightVm
                        {
                          Origin= "MZL",
                          Destination= "MDE",
                          FlightNumber= "8001",
                          Price= 200,
                          TransportName= "CO",
                          TransportId= null
                        },
                        new FlightVm
                        {
                          Origin= "MDE",
                          Destination= "BCN",
                          FlightNumber= "8004",
                          Price= 500,
                          TransportName= "CO",
                          TransportId= null
                        }
                    }
                },
                new JourneyVm
                {
                    Origin= "mzl",
                    Destination= "bcn",
                    Price= 900,
                    Flights = new List<FlightVm>
                    {
                        new FlightVm
                        {
                                  Origin= "MZL",
                        Destination= "CTG",
                        FlightNumber= "8002",
                        Price= 200,
                        TransportName= "CO",
                        TransportId= null
                        },
                        new FlightVm
                        {
                        Origin= "CTG",
                        Destination= "MDE",
                        FlightNumber= "9009",
                        Price= 200,
                        TransportName= "CO",
                        TransportId= null
                        },
                        new FlightVm
                        {
                        Origin= "MDE",
                        Destination= "BCN",
                        FlightNumber= "8004",
                        Price= 500,
                        TransportName= "CO",
                        TransportId= null
                        }


                    }

                }
            };
        }
    }
}


