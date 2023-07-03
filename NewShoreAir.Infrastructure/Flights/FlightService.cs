using MediatR;
using Microsoft.Extensions.Logging;
using NewShoreAir.Application.Contracts.Flight;
using NewShoreAir.Application.Exceptions;
using NewShoreAir.Application.Features.Categories.Commands.CreateJourney;
using NewShoreAir.Application.Features.Journeys.Queries.GetJourneyByOriginDestination;
using NewShoreAir.Application.Models;
using NewShoreAir.Domain;
using Newtonsoft.Json;

namespace NewShoreAir.Infrastructure.Flights
{
    public class FlightService : IFlightService
    {
        private readonly ILogger<FlightService> _logger;
        private List<FligthExternalVm>? ExternalVmList;
        private readonly IMediator _mediator;

        public FlightService(ILogger<FlightService> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<JourneyResponse> GetJourney(JourneyRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Origin))
            {
                throw new ArgumentNullException($"You must enter an origin {request.Origin}");
            }
            if (string.IsNullOrWhiteSpace(request.Destination))
            {
                throw new ArgumentNullException($"You must enter a destination {request.Destination}");
            }

            JourneyByOriginDestinationQuery getJourneyByOriginDestinationQuery = new()
            {
                Origin = request.Origin,
                Destination = request.Destination,
                NumberMaxFlight = request.NumberMaxFlight
            };
            var result = await _mediator.Send(getJourneyByOriginDestinationQuery);
            if (result.Count == 0)
            {
                result = await GetCalculateJourney(request);
                if (result.Count > 0)
                {
                    try
                    {
                        CreateJourneyCommand newJourney = new CreateJourneyCommand()
                        {
                            Journeys = result
                        };
                        await _mediator.Send(newJourney);
                    }
                    catch(Exception ex)
                    {
                        _logger.LogError(ex.Message);
                    }                    
                }
                else
                {
                    throw new NotFoundException($"No route found with source {request.Origin} and destination {request.Destination}");
                }
            }

            return new JourneyResponse
            {
                Journeys = result
            };

        }
        public async Task<List<JourneyVm>> GetCalculateJourney(JourneyRequest request)
        {
            List<JourneyVm> journeys = new List<JourneyVm>();
            if (ExternalVmList == null)
            {
                ExternalVmList = await GetFligths();
            }

            List<FligthExternalVm> fligths = ExternalVmList.Where(x => x.DepartureStation.ToUpper() == request.Origin.ToUpper()).ToList();
            if (fligths.Count > 0)
            {
                foreach (FligthExternalVm flight in fligths)
                {
                    List<FligthExternalVm> fligthsValidated = ExternalVmList.Where(x => x.DepartureStation.ToUpper() != request.Origin.ToUpper()).ToList();
                    if(flight.DepartureStation.ToUpper() == request.Origin.ToUpper() && flight.ArrivalStation.ToUpper() == request.Destination.ToUpper())
                    {                       
                        journeys.Add(new JourneyVm
                        {
                            Origin = request.Origin,
                            Destination = request.Destination,
                            Flights = new List<FlightVm>() 
                            {
                                new FlightVm
                                {
                                    Origin = flight.DepartureStation,
                                    Destination = flight.ArrivalStation,
                                    TransportName = flight.FlightCarrier,
                                    FlightNumber = flight.FlightNumber,
                                    Price = flight.Price
                                }
                            },                           
                            Price = flight.Price
                        });
                    }
                    else
                    {
                        JourneyRequest newRequest = new JourneyRequest()
                        {
                            Origin = flight.ArrivalStation,
                            Destination = request.Destination,
                            NumberMaxFlight = request.NumberMaxFlight
                        };

                        List<List<FlightVm>> listFlightRoute;
                        List<FlightVm> flightRoute = new();
                        GetFlightRoute(newRequest, flightRoute, fligthsValidated, out listFlightRoute);

                        foreach (List<FlightVm> scenario in listFlightRoute)
                        {
                            scenario.Insert(0, new FlightVm
                            {
                                Origin = flight.DepartureStation,
                                Destination = flight.ArrivalStation,
                                FlightNumber = flight.FlightNumber,
                                Price = flight.Price,
                                TransportName = flight.FlightCarrier
                            });

                            journeys.Add(new JourneyVm
                            {
                                Origin = request.Origin,
                                Destination = request.Destination,
                                Flights = scenario,
                                Price = scenario.Sum(x => x.Price)
                            });
                        }
                    }                    

                }
            }

            return journeys;

        }
        public List<FlightVm> GetFlightRoute(JourneyRequest request, List<FlightVm> flightRoute, List<FligthExternalVm> fligths, out List<List<FlightVm>> listFlightRoute)
        {
            listFlightRoute = new List<List<FlightVm>>();
            List<FligthExternalVm> fligthExist = fligths.Where(x => x.DepartureStation.ToUpper() == request.Origin.ToUpper() && x.ArrivalStation.ToUpper() == request.Destination.ToUpper()).ToList();
            if (fligthExist.Count == 0)
            {
                var stoverFlights = fligths.Where(x => x.DepartureStation.ToUpper() == request.Origin.ToUpper()).ToList();

                if (stoverFlights.Count > 0)
                {
                    foreach (FligthExternalVm stoverFlight in stoverFlights)
                    {
                        List<FligthExternalVm> fligthsProcess = fligths.Where(x => x.DepartureStation.ToUpper() != request.Origin.ToUpper()).ToList();

                        flightRoute.Add(new FlightVm
                        {
                            Origin = stoverFlight.DepartureStation,
                            Destination = stoverFlight.ArrivalStation,
                            FlightNumber = stoverFlight.FlightNumber,
                            Price = stoverFlight.Price,
                            TransportName = stoverFlight.FlightCarrier
                        });

                        JourneyRequest newRequest = new JourneyRequest()
                        {
                            Origin = stoverFlight.ArrivalStation,
                            Destination = request.Destination,
                            NumberMaxFlight = request.NumberMaxFlight
                        };
                        List<List<FlightVm>> listFlightRouteTemp;
                        int numberFlight = flightRoute.Count + 2;
                        flightRoute = GetFlightRoute(newRequest, flightRoute, fligthsProcess, out listFlightRouteTemp);
                        if (request.NumberMaxFlight > 0 && numberFlight >= request.NumberMaxFlight)
                        {
                            return new List<FlightVm>();
                        }
                        if (flightRoute.Count > 0 && listFlightRouteTemp.Count > 0)
                        {
                            foreach (List<FlightVm> routes in listFlightRouteTemp)
                            {
                                listFlightRoute.Add(routes);
                            }
                        }

                    }
                    return flightRoute;
                }
                else
                {
                    return new List<FlightVm>();
                }
            }
            else
            {
                int numberFlight = flightRoute.Count + 1;
                if (request.NumberMaxFlight > 0 && numberFlight >= request.NumberMaxFlight)
                {
                    return new List<FlightVm>();
                }

                List<FlightVm> listRoute = flightRoute.ToList();

                foreach (FligthExternalVm fligth in fligthExist)
                {
                    List<FlightVm> listScenario = listRoute.ToList();

                    FlightVm newFligth = new()
                    {
                        Origin = fligth.DepartureStation,
                        Destination = fligth.ArrivalStation,
                        FlightNumber = fligth.FlightNumber,
                        Price = fligth.Price,
                        TransportName = fligth.FlightCarrier
                    };
                    listScenario.Add(newFligth);
                    flightRoute.Add(newFligth);
                    listFlightRoute.Add(listScenario);
                }
                return flightRoute;
            }
        }
        public async Task<List<FligthExternalVm>> GetFligths()
        {
            try
            {
                string baseUrl = "https://recruiting-api.newshore.es/api/";
                string endPoint = "flights/2";
                HttpClient Conexion = new()
                {
                    BaseAddress = new Uri(baseUrl)
                };
                var response = await Conexion.GetStringAsync(endPoint);
                List<FligthExternalVm>? result = JsonConvert.DeserializeObject<List<FligthExternalVm>>(response);
                if (result == null)
                {
                    _logger.LogError("No flight information found");
                    throw new BadRequestException($"No flight information found in api {baseUrl}{endPoint}");

                }

                return result;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }


        }


    }
}
