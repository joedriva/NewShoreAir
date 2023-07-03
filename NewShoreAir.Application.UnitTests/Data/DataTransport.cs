using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Application.UnitTests.Data
{
    public static class DataTransport
    {
        public static List<Transport> GetDataTransport()
        {

            return new List<Transport>()
            {
                new Transport   {
                    Id = 1,
                    Name = "CO"
                }

            };


        }
    }

}
