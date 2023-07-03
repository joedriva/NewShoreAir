using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;
using NewShoreAir.Application.Features.Categories.Commands.CreateJourney;
using NewShoreAir.Application.Mappings;
using NewShoreAir.Application.UnitTests.Mocks;
using NewShoreAir.Infrastructure.Repositories;
using NewShoreAir.Application.Contracts.Flight;
using NewShoreAir.Application.UnitTests.Data;
using NewShoreAir.Infrastructure.Flights;
using NewShoreAir.Application.UnitTests.Request;

namespace NewShoreAir.Application.UnitTests.Features.Journey.Commands.CreateJourney
{
    public class CreateJourneyCommandHandlerXUnitTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<ILogger<CreateJourneyCommandHandler>> _logger;

        public CreateJourneyCommandHandlerXUnitTests()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(x =>
            {
                x.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _logger = new Mock<ILogger<CreateJourneyCommandHandler>>();

        }

        [Fact]
        public async Task CreateJourneyCommand_InputJourney_returnNumber()
        {

            CreateJourneyCommand JourneyRequest = new()
            {
                Journeys = RequestCreateJourney.GetData()
            };

            var handler = new CreateJourneyCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);
            var result = await handler.Handle(JourneyRequest, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }

    }
}
