using AutoMapper;
using IAS.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;

namespace IAS.Application.Features.Service.Commands
{
  public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
  {
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateServiceCommandHandler> _logger;

    public CreateServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CreateServiceCommandHandler> logger)
    {
      _unitOfWork = unitOfWork;
      _mapper = mapper;
      _logger = logger;
    }

    public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
    {
      var serviceEntity = _mapper.Map<Service>(request);
      _unitOfWork.ServiceRepository.Add(serviceEntity);
      var result = await _unitOfWork.Complete();

      if (result <= 0)
      {
        _logger.LogError("No se pudo insertar el servicio");
        throw new Exception($"No se pudo insertar el servicio");
      }

      _logger.LogInformation($"Servicio {serviceEntity} fue insertado correctamente");

      return serviceEntity.Id;
    }
  }
}
