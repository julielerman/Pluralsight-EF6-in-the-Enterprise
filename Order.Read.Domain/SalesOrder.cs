using System;
using System.Collections.Generic;
using MvcSalesApp.SharedKernel;
using Order.Domain.ValueObjects;

namespace Order.Read.Domain
{
  public class SalesOrder : Entity
  {
    protected SalesOrder()
    {
      LineItems = new List<LineItem>();
    }
    public DateTime OrderDate { get; private set; }
    public DateTime? DueDate { get; private set; }
    public bool OnlineOrder { get; private set; }
    public string PurchaseOrderNumber { get; private set; }
    public string Comment { get; private set; }
    public int PromotionId { get; private set; }
    public Address ShippingAddress { get; private set; }
    public CustomerStatus CurrentCustomerStatus { get; private set; }
    public double Discount
    {
      get { return CustomerDiscount + PromoDiscount; }
    }
    public double CustomerDiscount { get; private set; }
    public double PromoDiscount { get; private set; }
    public string SalesOrderNumber { get; private set; }
    public int CustomerId { get; private set; }
    public double SubTotal { get; private set; }
    public ICollection<LineItem> LineItems { get; private set; }
    public void SetShippingAddress(Address address)
    {
      ShippingAddress = Address.Create(address.Street, address.City,
        address.StateProvince, address.PostalCode);
    }
    public decimal CalculateShippingCost()
    {
      //items, quantity, price,disounts, total weight of item
      //this is the job of a microservice we can call out to
      throw new NotImplementedException();
    }
  }
}