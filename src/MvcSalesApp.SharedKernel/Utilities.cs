using System;
using System.Web;

namespace MvcSalesApp.SharedKernel
{
  //there is actually a CookieContainer API in .NET but I'm leaving this part as demo-ware

  public class CookieUtilities
  {
    public static HttpCookie BuildCartCookie(string createdCartCookie, DateTime cartCookieExpires) {
      var cartCookie = new HttpCookie("PluralsightEF6ShoppingCartDemo_Cart");
      cartCookie.Value = createdCartCookie;
      cartCookie.Expires = cartCookieExpires;
      return cartCookie;
    }

    public static string CreateCookie(DateTime expiresDateTime) {
      return $"cName=SalesAppCookie|cGuid={Guid.NewGuid()}|cExpires={expiresDateTime.ToUniversalTime()}";
    }

    public static bool IsCartCookie(string cookie) {
      var crumbs = cookie.Split(Convert.ToChar("|"));
      if (crumbs[0] != "cName=SalesAppCookie") return false;
      if (!crumbs[1].StartsWith("cGuid=")) return false;
      var guidCheck = crumbs[1].Substring("cGuid=".Length + 1);
      Guid guidResult;
      if (!Guid.TryParse(guidCheck, out guidResult)) return false;
      if (!crumbs[2].StartsWith("cExpires=")) return false;
      return true;
    }

    //{
    //  StringBuilder sb = new StringBuilder();
    //  // Get cookie from the current request.
    //  HttpCookie cookie = Request.Cookies.Get("DateCookieExample");

    //  // Check if cookie exists in the current request.
    //  if (cookie == null) {
    //    sb.Append("Cookie was not received from the client. ");
    //    sb.Append("Creating cookie to add to the response. <br/>");
    //    // Create cookie.
    //    cookie = new HttpCookie("DateCookieExample");
    //    // Set value of cookie to current date time.
    //    cookie.Value = DateTime.Now.ToString();
    //    // Set cookie to expire in 10 minutes.
    //    cookie.Expires = DateTime.Now.AddMinutes(10d);
    //    // Insert the cookie in the current HttpResponse.
    //    Response.Cookies.Add(cookie);
    //  }
    //  else {
    //    sb.Append("Cookie retrieved from client. <br/>");
    //    sb.Append("Cookie Name: " + cookie.Name + "<br/>");
    //    sb.Append("Cookie Value: " + cookie.Value + "<br/>");
    //    sb.Append("Cookie Expiration Date: " +
    //        cookie.Expires.ToString() + "<br/>");
    //  }
    //  Label1.Text = sb.ToString();
    //}
  }
}