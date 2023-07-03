using AutoMapper;
using Moq;
using Shouldly;
using Xunit;
using NewShoreAir.Application.Mappings;
using NewShoreAir.Application.UnitTests.Mocks;
using NewShoreAir.Infrastructure.Repositories;
using NewShoreAir.Application.Features.Journeys.Queries.GetJourneyByOriginDestination;
using NewShoreAir.Application.Models;

namespace NewShoreAir.Application.UnitTests.Features.Journey.Queries.GetCategories
{
    public class JourneyByOriginDestinationQueryHandlerXUnitTests
    {

        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;

        public JourneyByOriginDestinationQueryHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            MockAsyncRepository.AddDataJourney(_unitOfWork.Object.NewShoreAirDbContext);
        }

        [Fact]
        public async Task GetJourneyByOriginDestination_inputOriginDestination_returnTrue()
        {
            var handler = new JourneyByOriginDestinationQueryHandler(_unitOfWork.Object, _mapper);
            var request = new JourneyByOriginDestinationQuery
            {
                Origin = "MZL",
                Destination = "BCN"
            };

            var result = await handler.Handle(request, CancellationToken.None);
            result.ShouldBeOfType<List<JourneyVm>>();

        }

    }
}
