<%@ WebHandler Language="C#" Class="SessionFillService" %>

using System;
using System.Web;

public class SessionFillService : IHttpHandler, System.Web.SessionState.IRequiresSessionState
{
    
    public void ProcessRequest (HttpContext context) {

       
        xyoa.LoginFree.SetSession(context.Session);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}