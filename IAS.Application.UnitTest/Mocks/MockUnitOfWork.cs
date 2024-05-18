using IAS.Infrastructure.Persistence;
using IAS.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace IAS.Application.UnitTest.Mocks
{
  public static class MockUnitOfWork
  {
    public static Mock<UnitOfWork> GetUnitOfWork()
    {
      Guid dbContextId = Guid.NewGuid();
      var options = new DbContextOptionsBuilder<ServiceDbContext>()
        .UseInMemoryDatabase(databaseName: $"ServiceDbContext-{dbContextId}")
        .Options;

      var taskDbContextFake = new ServiceDbContext(options);
      taskDbContextFake.Database.EnsureDeleted();
      var mockUnitOfWork = new Mock<UnitOfWork>(taskDbContextFake);

      return mockUnitOfWork;
    }
  }
}
