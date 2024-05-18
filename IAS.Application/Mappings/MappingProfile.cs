using AutoMapper;
using IAS.Application.Features.Service.Commands;
using IAS.Application.Features.Service.Queries.Vms;
using IAS.Domain.Models;

namespace IAS.Application.Mappings
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<CreateServiceCommand, Service>();
      CreateMap<Service,  ServiceVm>();
    }
  }
}
