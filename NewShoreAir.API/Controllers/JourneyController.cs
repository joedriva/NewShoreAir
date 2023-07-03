using MediatR;
using Microsoft.AspNetCore.Mvc;
using NewShoreAir.Application.Contracts.Flight;
using NewShoreAir.Application.Models;
using System.Net;

namespace NewShoreAir.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class JourneyController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public JourneyController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost("journey")]
        [ProducesResponseType(typeof(JourneyResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<JourneyResponse>> Register([FromBody] JourneyRequest request)
        {
            return Ok(await _flightService.GetJourney(request));
        }       

        
    }
}
