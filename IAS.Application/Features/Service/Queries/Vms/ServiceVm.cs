using IAS.Domain.Models;

namespace IAS.Application.Features.Service.Queries.Vms
{
  public class ServiceVm
  {
    public int Id { get; set; }
    public string? Addres { get; set; }
    public string? Description { get; set; }
    public string? InitDateService { get; set; }
    public string? EndDateAndTimeService { get; set; }
    public virtual Technician? Technician { get; set; }
  }
}
