using NewShoreAir.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Domain
{
    public class JourneyFlight : BaseDomainModel
    {
        public int JourneyId { get; set; }
        public Journey? Journey { get; set; }
        public int FlightId { get; set; }
        public Flight? Flight { get; set; }
    }
}
