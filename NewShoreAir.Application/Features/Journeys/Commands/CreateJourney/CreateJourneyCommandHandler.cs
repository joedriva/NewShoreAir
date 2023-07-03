using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using NewShoreAir.Application.Contracts.Persistence;
using NewShoreAir.Application.Exceptions;
using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using System.Collections.Generic;

namespace NewShoreAir.Application.Features.Categories.Commands.CreateJourney
{
    public class CreateJourneyCommandHandler : IRequestHandler<CreateJourneyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateJourneyCommandHandler> _logger;

        public CreateJourneyCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateJourneyCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<int> Handle(CreateJourneyCommand request, CancellationToken cancellationToken)
        {
            List<Transport> addedTransport = new();
            List<Flight> addedFlight = new();

            foreach (JourneyVm journey in request.Journeys!)
            {
                List<FlightVm> flights = journey.Flights!.ToList();
                Journey journeyEntity = _mapper.Map<Journey>(journey);
                journeyEntity.Flights = null;
                _unitOfWork.Repository<Journey>().AddEntity(journeyEntity);

                foreach (FlightVm flight in flights)
                {
                    Flight? flightEntity = addedFlight.FirstOrDefault(x => x.FlightNumber == flight.FlightNumber);
                    if(flightEntity == null)
                    {
                        flightEntity = await FlightValidate(flight, addedTransport);
                        if(flightEntity.Id == 0)
                        {
                            addedFlight.Add(flightEntity);
                        }
                    }

                    JourneyFlight newJourneyFlight = new JourneyFlight()
                    {
                        Journey = journeyEntity,
                        Flight = flightEntity
                    };
                    _unitOfWork.Repository<JourneyFlight>().AddEntity(newJourneyFlight);
                }

            }           
            var result = await _unitOfWork.Complete();
            if (result <= 0)
            {
                throw new BadRequestException($"An error occurred when entering the journey");
            }
            _logger.LogInformation($"The journey with origin  y destination was successfully created");
            return 1;
        }

        public async Task<Transport> TransporValidate(string transportName)
        {
            Transport transportEntity = new Transport();
            var transport = await _unitOfWork.Repository<Transport>().GetAsync(x => x.Name == transportName);
            if (transport.Count == 0)
            {
                
                    transportEntity = new Transport()
                    {
                        Name = transportName
                    };
                    _unitOfWork.Repository<Transport>().AddEntity(transportEntity);               
            }
            else
            {
                transportEntity = transport[0];
            }
            return transportEntity;
        }

        public async Task<Flight> FlightValidate(FlightVm flight, List<Transport> addTransport)
        {

            Flight flightEntity;
            var flightsEntity = await _unitOfWork.Repository<Flight>().GetAsync(x => x.FlightNumber == flight.FlightNumber);

            if (flightsEntity.Count > 0)
            {
                flightEntity = flightsEntity[0];
            }
            else
            {
                flightEntity = _mapper.Map<Flight>(flight);
                Transport? transportEntity = addTransport.FirstOrDefault(x => x.Name == flight.TransportName);
                if (transportEntity == null)
                {
                    transportEntity = await TransporValidate(flight.TransportName);
                    addTransport.Add(transportEntity);
                }
                

                flightEntity.Transport = transportEntity;
                _unitOfWork.Repository<Flight>().AddEntity(flightEntity);
            }

            return flightEntity;

        }


    }
}
