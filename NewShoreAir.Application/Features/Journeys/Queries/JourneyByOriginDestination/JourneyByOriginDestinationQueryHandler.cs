using AutoMapper;
using MediatR;
using NewShoreAir.Application.Contracts.Persistence;
using NewShoreAir.Application.Models;
using NewShoreAir.Domain;

namespace NewShoreAir.Application.Features.Journeys.Queries.GetJourneyByOriginDestination
{
    public class JourneyByOriginDestinationQueryHandler : IRequestHandler<JourneyByOriginDestinationQuery, List<JourneyVm>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public JourneyByOriginDestinationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<JourneyVm>> Handle(JourneyByOriginDestinationQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Repository<Journey>().GetAsync(x => x.Origin!.ToUpper() == request.Origin.ToUpper() 
            && x.Destination!.ToUpper() == request.Destination.ToUpper()
            && (request.NumberMaxFlight == null || request.NumberMaxFlight == 0 || x.Flights!.Count <= request.NumberMaxFlight)
            , null, "Flights.Transport");
            return _mapper.Map<List<JourneyVm>>(result);
        }
    }
}
