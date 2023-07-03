using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.UnitTests.Data
{
    public static class DataJourney
    {
        public static List<Journey> GetDataJourney()
        {

            return new List<Journey>()
            {
                new Journey   {
                  Id = 1,
                  Origin= "MZL",
                  Destination= "BCN",
                  Price= 700
                },
                new Journey
                {
                  Id = 2,
                  Origin= "MZL",
                  Destination= "BCN",
                  Price= 900
                }
            };
        }
    }

}
