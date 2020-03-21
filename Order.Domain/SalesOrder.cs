using System;
using System.Collections.Generic;
using System.Linq;
using MvcSalesApp.SharedKernel;
using Order.Domain.DTOs;
using Order.Domain.ValueObjects;

namespace Order.Domain
{
  public class SalesOrder : Entity
  {
    private readonly Customer _customer;
    private readonly List<LineItem> _lineItems;

    public static SalesOrder Create(IEnumerable<CartItem> cartItems, Customer customer) {
      var order = new SalesOrder(cartItems, customer);
      return order;
    }

    private SalesOrder(IEnumerable<CartItem> cartItems, Customer customer) : this(){
      Id = Guid.NewGuid();
      _customer = customer;
      CustomerId = customer.CustomerId;
      SetShippingAddress(customer.PrimaryAddress);
      ApplyCustomerStatusDiscount();
      foreach (var item in cartItems)
      {
        CreateLineItem(item.ProductId, (double) item.Price, item.Quantity);
      }
      _customer = customer;
    }

    protected SalesOrder()
    {
      _lineItems = new List<LineItem>();
      Id = Guid.NewGuid();
      OrderDate = DateTime.Now;
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

    public ICollection<LineItem> LineItems
    {
      get { return _lineItems; }
    }

    public void CreateLineItem(int productId, double listPrice, int quantity)
    {
      //NOTE: add some validations such as:
      //quantity can't be 0 and if it's >1000 give a discount
      // customer is a gold. give another discount
      var item = LineItem.Create(Id, productId, quantity, listPrice,
        CustomerDiscount + PromoDiscount);
      _lineItems.Add(item);
    }

    public void SetShippingAddress(Address address)
    {
      ShippingAddress = Address.Create(address.Street, address.City,
        address.StateProvince, address.PostalCode);
    }

    public bool Validate()
    {
      if (LineItems.Any())
      {
        return true;
      }
      return false;
    }

    public decimal CalculateShippingCost()
    {
      //items, quantity, price,disounts, total weight of item
      //this is the job of a microservice we can call out to
      throw new NotImplementedException();
    }

    public void ApplyCustomerStatusDiscount()
    {
      var status = CustomerStatus.New;
      if (_customer != null)
        status = _customer.Status;
      switch (status)
      {
        case CustomerStatus.Silver:
          CustomerDiscount = CustomerDiscounts.SilverDiscount;
          break;

        case CustomerStatus.Gold:
          CustomerDiscount = CustomerDiscounts.GoldDiscount;
          break;

        case CustomerStatus.Platinum:
          CustomerDiscount = CustomerDiscounts.PlatinumDiscount;
          break;

        default:
        {
          CustomerDiscount = 0;
          break;
        }
      }
    }

    public void SetOrderDetails(bool onLineOrder, string PONumber, string comment, int promotionId, double promoDiscount)
    {
      OnlineOrder = onLineOrder;
      PurchaseOrderNumber = PONumber;
      Comment = comment;

      PromotionId = promotionId;
      PromoDiscount = promoDiscount;
    }
  }
}