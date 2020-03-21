using System;
using Maintenance.Domain.Enums;

namespace Maintenance.Domain.ViewModels
{
  public class OrderViewModel
  {
    public int OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public OrderSource OrderSource { get; set; }
    public int CustomerId { get; set; }
  }
}