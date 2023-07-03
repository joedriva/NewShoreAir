using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewShoreAir.Application.Contracts.Persistence;
using NewShoreAir.Infrastructure.Persistence;
using NewShoreAir.Infrastructure.Repositories;

namespace NewShoreAir.Application.UnitTests.Mocks
{
    public static class MockUnitOfWork
    {
        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<NewShoreAirDbContext>()
               .UseInMemoryDatabase(databaseName: $"NewShoreAirDbContext-{dbContextId}")
               .Options;

            var streamerDbContextFake = new NewShoreAirDbContext(options);

            streamerDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(streamerDbContextFake);

            return mockUnitOfWork;
        }
    }
}
