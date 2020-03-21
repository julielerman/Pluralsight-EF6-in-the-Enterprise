using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvcSalesApp.Tests.SharedKernel
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void NewCookieHasCorrectStartingText()
    {
     
      var cookie=MvcSalesApp.SharedKernel.CookieUtilities.CreateCookie(DateTime.Now);
     Assert.AreEqual("cName=SalesAppCookie|cGuid=", cookie.Substring(0,27));
  

    }
    [TestMethod]
    public void NewCookieHasExpirationDate() {
      var date = DateTime.Now;
      var cookie = MvcSalesApp.SharedKernel.CookieUtilities.CreateCookie(date);
        Assert.AreEqual("cExpires="+ date.ToUniversalTime(), cookie.Substring(cookie.IndexOf("cExpires")));


    }
  }
}
