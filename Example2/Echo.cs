using System;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

namespace Example2
{
  public class Echo : WebSocketService
  {
    protected override void OnMessage (MessageEventArgs e)
    {
      var name = Context.QueryString ["name"] ?? String.Empty;
      var msg = name.Length > 0
              ? String.Format ("'{0}' to {1}", e.Data, name)
              : e.Data;

      Send (msg);
    }

    protected override bool ValidateCookies (
      CookieCollection request, CookieCollection response)
    {
      foreach (Cookie cookie in request) {
        cookie.Expired = true;
        response.Add (cookie);
      }

      return true;
    }
  }
}
