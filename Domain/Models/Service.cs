﻿using IAS.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace IAS.Domain.Models
{
  public class Service : BaseDomainModel
  {
    public int Id { get; set; }
    [Column(TypeName = "varchar(30)")]
    public string? Addres { get; set; }
    [Column(TypeName = "varchar(100)")]
    public string? Description { get; set; }
    public string? InitDateService { get; set; }
    public string? EndDateAndTimeService { get; set; }
    public int TechnicianId { get; set; }
    public virtual Technician? Technician { get; set; }
  }
}
