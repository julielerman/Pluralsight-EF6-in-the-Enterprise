using MvcSalesApp.SharedKernel;
using System;

namespace Order.Write.Domain
{
  public class LineItem : Entity
  {
    public static LineItem Create(Guid orderId, int productId, int quantity, double unitPrice, double unitPriceDiscount) {
      return new LineItem(orderId, productId, quantity, unitPrice, unitPriceDiscount);
    }

    private LineItem(Guid orderId, int productId, int quantity, double unitPrice, double unitPriceDiscount) {
      Id = Guid.NewGuid();
      SalesOrderId = orderId;
      Quantity = quantity;
      ProductId = productId;
      UnitPrice = unitPrice;
      UnitPriceDiscount = unitPriceDiscount;
    }

    //private LineItem() {
    //}

    public Guid SalesOrderId { get; private set; }
    public int ProductId { get; private set; }

    public int Quantity { get; private set; }
    public double? UnitPrice { get; private set; }
    public double? UnitPriceDiscount { get; private set; }

    public double LineTotal
    {
      get
      {
        if (UnitPrice != null) {
          if (UnitPriceDiscount != null)
            return Quantity * (UnitPrice.Value * (1 - UnitPriceDiscount.Value));
        }
        return 0;
      }
    }

    public int? ShipmentId { get; set; }

    public void AdjustQuantity(int quantity) {
      Quantity = quantity;
    }
  }
}