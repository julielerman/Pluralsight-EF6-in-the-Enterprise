using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoppingCart.Data;

namespace ShoppingCart.Tests.FullDb
{
  [TestClass]
  public class ShoppingCartViaFullDatabaseTests
    {
    private ShoppingCartContext _context=new ShoppingCartContext();
    private ReferenceContext _refContext=new ReferenceContext();

    [TestMethod]
    public void ProductsHaveValuesWhenReturnedFromRepo() {
      var data = new WebSiteOrderData(_context, _refContext);
      var productList = data.GetProductsWithCategoryForShoppingAsync().Result;
      Assert.AreNotEqual("", productList[0].Name);
    }

    [TestMethod]
    public void CanGetProductListAsync() {
      var repo = new WebSiteOrderData(_context, _refContext);
      var result = repo.GetProductsWithCategoryForShoppingAsync().Result;
      Assert.IsNotNull(result);
    }
  }
}
