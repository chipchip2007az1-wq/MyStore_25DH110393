using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _25dh230038_mystore.Areas.Admin.Controllers
{
    // Gắn [AdminAuthorize] lên controller -> chỉ vào được khi đã đăng nhập Admin
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        // Đã đăng nhập Admin khi Session["AdminUser"] có giá trị
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return httpContext.Session != null && httpContext.Session["AdminUser"] != null;
        }

        // Chưa đăng nhập -> chuyển về trang Login của Admin, nhớ lại trang đang muốn vào
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
            {
                area = "admin",
                controller = "AdminAccount",
                action = "Login",
                returnUrl = filterContext.HttpContext.Request.RawUrl
            }));
        }
    }
}