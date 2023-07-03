using MediatR;
using NewShoreAir.Application.Models;
using NewShoreAir.Domain;

namespace NewShoreAir.Application.Features.Categories.Commands.CreateJourney
{
    public class CreateJourneyCommand : IRequest<int>
    {
        public List<JourneyVm>? Journeys { get; set; }
    }
}
