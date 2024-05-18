using System.ComponentModel.DataAnnotations.Schema;

namespace IAS.Domain.Models
{
  public class Technician
  {
    public int Id { get; set; }
    [Column(TypeName = "varchar(30)")]
    public string? Name { get; set; }
  }
}
