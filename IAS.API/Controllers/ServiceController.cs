using IAS.Application.Contracts.Persistence;
using IAS.Application.Features.Service.Commands;
using IAS.Application.Features.Service.Queries.Vms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace IAS.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ServiceController : Controller
  {
    private readonly IMediator _mediator;
    private readonly IServiceRepository _serviceRepository;

    public ServiceController(IMediator mediator, IServiceRepository serviceRepository)
    {
      _mediator = mediator;
      _serviceRepository = serviceRepository;
    }

    [HttpGet("ById/{id:int}", Name = "GetServiceById")]
    [ProducesResponseType(typeof(IEnumerable<ServiceVm>), (int)HttpStatusCode.OK)]
    public async Task<ActionResult<IEnumerable<ServiceVm>>> GetServiceById(int id)
    {
      var serviceById = await _serviceRepository.GetByIdAsync(id);

      return Ok(serviceById);
    }

    [HttpPost(Name = "CreateService")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<ActionResult<int>> CreateService([FromBody] CreateServiceCommand command)
    {
      return await _mediator.Send(command);
    }
  }
}
