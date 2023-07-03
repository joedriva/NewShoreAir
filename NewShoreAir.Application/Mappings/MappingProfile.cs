using AutoMapper;
using NewShoreAir.Application.Features.Categories.Commands.CreateJourney;
using NewShoreAir.Application.Models;
using NewShoreAir.Domain;

namespace NewShoreAir.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateJourneyCommand, Journey>();
            //CreateMap<UpdateJourneyCommand, Journey>();
            CreateMap<Journey, JourneyVm>().ReverseMap();
            CreateMap<Flight, FlightVm>()
                .ForMember(x => x.TransportName, y => y.MapFrom(z => z.Transport!.Name));
            CreateMap<FlightVm, Flight>();
            CreateMap<FlightVm, FlightVm>();
        }
    }
}
