using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.UnitTests.Data
{
    public static class DataFlightsExternal
    {
        public static List<FligthExternalVm> GetDataFligths()
        {

            return new List<FligthExternalVm>()
            {
                new FligthExternalVm
                {
                    DepartureStation = "MZL",
                    ArrivalStation = "MDE",
                    FlightCarrier = "CO",
                    FlightNumber = "8001",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "MZL",
                    ArrivalStation = "CTG",
                    FlightCarrier = "CO",
                    FlightNumber = "8002",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "PEI",
                    ArrivalStation = "BOG",
                    FlightCarrier = "CO",
                    FlightNumber = "8003",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "MDE",
                    ArrivalStation = "BCN",
                    FlightCarrier = "CO",
                    FlightNumber = "8004",
                    Price = 500
                },
                new FligthExternalVm
                {
                    DepartureStation = "CTG",
                    ArrivalStation = "CAN",
                    FlightCarrier = "CO",
                    FlightNumber = "8005",
                    Price = 300
                },
                new FligthExternalVm
                {
                    DepartureStation = "BOG",
                    ArrivalStation = "MAD",
                    FlightCarrier = "CO",
                    FlightNumber = "8006",
                    Price = 500
                },
                new FligthExternalVm
                {
                    DepartureStation = "BOG",
                    ArrivalStation = "MEX",
                    FlightCarrier = "CO",
                    FlightNumber = "8007",
                    Price = 300
                },
                new FligthExternalVm
                {
                    DepartureStation = "MZL",
                    ArrivalStation = "PEI",
                    FlightCarrier = "CO",
                    FlightNumber = "8008",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "MDE",
                    ArrivalStation = "CTG",
                    FlightCarrier = "CO",
                    FlightNumber = "8009",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "BOG",
                    ArrivalStation = "CTG",
                    FlightCarrier = "CO",
                    FlightNumber = "8010",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "MDE",
                    ArrivalStation = "MZL",
                    FlightCarrier = "CO",
                    FlightNumber = "9001",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "CTG",
                    ArrivalStation = "MZL",
                    FlightCarrier = "CO",
                    FlightNumber = "9002",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "BOG",
                    ArrivalStation = "PEI",
                    FlightCarrier = "CO",
                    FlightNumber = "9003",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "BCN",
                    ArrivalStation = "MDE",
                    FlightCarrier = "ES",
                    FlightNumber = "9004",
                    Price = 500
                },
                new FligthExternalVm
                {
                    DepartureStation = "CAN",
                    ArrivalStation = "CTG",
                    FlightCarrier = "MX",
                    FlightNumber = "9005",
                    Price = 300
                },
                new FligthExternalVm
                {
                    DepartureStation = "MAD",
                    ArrivalStation = "BOG",
                    FlightCarrier = "ES",
                    FlightNumber = "9006",
                    Price = 500
                },
                new FligthExternalVm
                {
                    DepartureStation = "MEX",
                    ArrivalStation = "BOG",
                    FlightCarrier = "MX",
                    FlightNumber = "9007",
                    Price = 300
                },
                new FligthExternalVm
                {
                    DepartureStation = "PEI",
                    ArrivalStation = "MZL",
                    FlightCarrier = "CO",
                    FlightNumber = "9008",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "CTG",
                    ArrivalStation = "MDE",
                    FlightCarrier = "CO",
                    FlightNumber = "9009",
                    Price = 200
                },
                new FligthExternalVm
                {
                    DepartureStation = "CTG",
                    ArrivalStation = "BOG",
                    FlightCarrier = "CO",
                    FlightNumber = "9010",
                    Price = 200
                }

            };


        }
    }

}
