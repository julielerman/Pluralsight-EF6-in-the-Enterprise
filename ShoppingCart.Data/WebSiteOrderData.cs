using System.Collections.Generic;
using System.IO;
using System.Linq;
using ShoppingCart.Domain;
using System.Data.Entity;
using System.Threading.Tasks;
using SharedKernel.Data;

namespace ShoppingCart.Data
{
  public class WebSiteOrderData
  {
    private readonly ShoppingCartContext _context;
    private readonly ReferenceContext _refContext;

    public WebSiteOrderData(ShoppingCartContext context, ReferenceContext refContext)
    {
      _context = context;
      _refContext = refContext;
    }

    public async Task<List<Product>> GetProductsWithCategoryForShoppingAsync()
    {
      return await _refContext.Products.AsNoTracking().ToListAsync();
    }


    public async Task<Product> GetFirstProductWithCategoryForShoppingAsync() {
      return await _refContext.Products.AsNoTracking().FirstOrDefaultAsync();
    }

    public List<Product> GetProductsWithCategoryForShopping() {
      return  _refContext.Products.AsNoTracking().ToList();
    }

    public RevisitedCart StoreCartWithInitialProduct(NewCart newCart)
    {
      if (newCart.CartItems.Count != 1) return null;
      CheckForExistingCustomer(newCart);
      _context.Carts.Add(newCart);
      _context.SaveChanges();
      var cart = RevisitedCart.CreateWithItems(newCart.CartId, newCart.CartItems);
      cart.SetCookieData(newCart.CartCookie, newCart.Expires);
      return cart;
    }

    private void CheckForExistingCustomer(NewCart newCart)
    {
      if (newCart.CustomerCookie != null)
      {
        var customerId = _refContext.Customers.AsNoTracking()
          .Where(c => c.CustomerCookie == newCart.CustomerCookie)
          .Select(c => c.CustomerId).FirstOrDefault();
        if (customerId > 0)
        {
          newCart.CustomerFound(customerId);
        }
      }
    }

    public RevisitedCart RetrieveCart(int cartId)
    {
      var cart = _context.Carts.AsNoTracking().Where(c => c.CartId == cartId).
        Select(c => new {c.CartId, c.CartItems}).SingleOrDefault();
      if (cart != null) return RevisitedCart.CreateWithItems(cart.CartId, cart.CartItems);
      return RevisitedCart.Create(cartId);
    }

    public RevisitedCart RetrieveCart(string cartCookie)
    {
      var cart = _context.Carts.AsNoTracking()
        .Where(c => c.CartCookie == cartCookie)
        .Select(c => new { c.CartId, c.CartItems }).SingleOrDefault();
      if (cart != null) return RevisitedCart.CreateWithItems(cart.CartId, cart.CartItems);
      return null;
    }

    public void StoreNewCartItem(CartItem item)
    {
      //item should be valid before we get here but one last check
      if (item.CartId == 0)
        throw new InvalidDataException("Cart Item is not associated with a cart",
          new InvalidDataException("CartId is 0"));
      _context.CartItems.Add(item);
      _context.SaveChanges();
    }

    public void UpdateItemsForExistingCart(RevisitedCart cart)
    {
      _context.Configuration.AutoDetectChangesEnabled = false;
      foreach (var item in cart.CartItems)
      {
        _context.CartItems.Attach(item);
      }
      _context.ChangeTracker.DetectChanges();
      _context.FixState();
      _context.SaveChanges();
    }
  }
}