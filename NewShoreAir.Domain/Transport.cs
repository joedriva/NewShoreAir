using NewShoreAir.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewShoreAir.Domain
{
    public class Transport : BaseDomainModel
    {
        public string? Name { get; set; }
        public ICollection<Flight>? Flights { get; set; }
    }
}
