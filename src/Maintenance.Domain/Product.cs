using System;
using System.Collections.Generic;

namespace Maintenance.Domain
{
  public class Product
  {
    public Product()
    {
      IsAvailable = true;
    //  Categories=new List<Category>();
    }

    public int ProductId { get; set; }
    public string Description { get; set; }
    public string Name { get; set; }
    public DateTime ProductionStart { get; set; }
    public bool IsAvailable { get; set; }
    public int CategoryId { get; set; }
   // public ICollection<Category> Categories { get; set; }

    public int MaxQuantity { get; set; }
    public decimal CurrentPrice { get; set; }

    public void RemoveFromProduction()
    {
      IsAvailable = false;
    }
  }
}