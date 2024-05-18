using AutoFixture;
using IAS.Domain.Models;
using IAS.Infrastructure.Persistence;

namespace IAS.Application.UnitTest.Mocks
{
  public static class MockServiceRepository
  {
    public static void AddDataTaskRepository(ServiceDbContext serviceDbContextFake)
    {
      var fixture = new Fixture();
      fixture.Behaviors.Add(new OmitOnRecursionBehavior());

      var serviceIn = fixture.CreateMany<Service>().ToList();

      serviceIn.Add(fixture.Build<Service>()
        .With(tr => tr.Id, 8001)
        .Without(tr => tr.User)
        .Create()
        );

      serviceDbContextFake.Services!.AddRange(serviceIn);
      serviceDbContextFake.SaveChanges();
    }
  }
}
