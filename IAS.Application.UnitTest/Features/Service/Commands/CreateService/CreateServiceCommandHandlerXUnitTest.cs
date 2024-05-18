using AutoMapper;
using IAS.Application.Features.Service.Commands;
using IAS.Application.Mappings;
using IAS.Application.UnitTest.Mocks;
using IAS.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAS.Application.UnitTest.Features.Service.Commands.CreateService
{
  public class CreateServiceCommandHandlerXUnitTest
  {
    private readonly IMapper _mapper;
    private readonly Mock<UnitOfWork> _unitOfWork;
    private readonly Mock<ILogger<CreateServiceCommandHandler>> _logger;

    public CreateServiceCommandHandlerXUnitTest()
    {
      _unitOfWork = MockUnitOfWork.GetUnitOfWork();
      var mapperConfig = new MapperConfiguration(c =>
      {
        c.AddProfile<MappingProfile>();
      });
      _mapper = mapperConfig.CreateMapper();

      _logger = new Mock<ILogger<CreateServiceCommandHandler>>();


      MockServiceRepository.AddDataTaskRepository(_unitOfWork.Object.ServiceDbContext);
    }
  }
}
