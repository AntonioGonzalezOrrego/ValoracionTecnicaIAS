using MediatR;

namespace IAS.Application.Features.Service.Commands
{
  public class CreateServiceCommand : IRequest<int>
  {
    public string? Addres { get; set; }
    public string? Description { get; set; }
    public string? InitDateService { get; set; }
    public string? EndDateAndTimeService { get; set; }
    public int TechId { get; set; }
  }
}
