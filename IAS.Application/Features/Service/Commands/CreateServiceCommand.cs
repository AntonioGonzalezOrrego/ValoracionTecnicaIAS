namespace IAS.Application.Features.Service.Commands
{
  public class CreateServiceCommand
  {
    public string? Addres { get; set; }
    public string? Description { get; set; }
    public string? InitDateService { get; set; }
    public string? EndDateService { get; }
    public int TechnicianId { get; set; }
  }
}
