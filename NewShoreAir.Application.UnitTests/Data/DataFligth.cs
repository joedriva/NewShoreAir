using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.UnitTests.Data
{
    public static class DataFligth
    {
        public static List<Flight> GetDataFligths()
        {

            return new List<Flight>()
            {
                new Flight
                {
                  Id = 1,
                  Origin= "MZL",
                  Destination= "MDE",
                  FlightNumber= "8001",
                  Price= 200,
                  TransportId= 1
                },
                new Flight
                {
                  Id = 2,
                  Origin= "MDE",
                  Destination= "BCN",
                  FlightNumber= "8004",
                  Price= 500,
                  TransportId= 1
                },
                new Flight
                {
                  Id = 3,
                  Origin= "MZL",
                  Destination= "CTG",
                  FlightNumber= "8002",
                  Price= 200,
                  TransportId= 1
                },
                new Flight
                {
                  Id = 4,
                  Origin= "CTG",
                  Destination= "MDE",
                  FlightNumber= "9009",
                  Price= 200,
                  TransportId= 1
                }
            };
        }
    }

}
