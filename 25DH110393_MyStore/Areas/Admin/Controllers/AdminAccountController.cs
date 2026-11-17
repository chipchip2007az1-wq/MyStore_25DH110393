using _25DH110393_MyStore.Models.VỉewModel;
using _25DH110393_MyStore.Models;
using System.Linq;
using System.Web.Mvc;

namespace _25dh230038_mystore.Areas.Admin.Controllers
{
    public class AdminAccountController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();
        private const string ROLE_ADMIN = "A";

        // GET: admin/AdminAccount/Login
        public ActionResult Login(string returnUrl)
        {
            if (Session["AdminUser"] != null) return RedirectToAction("Index", "Home");
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: admin/AdminAccount/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string username = model.Username.Trim();
                var user = db.Users.SingleOrDefault(u => u.Username == username
                                                      && u.Password == model.Password
                                                      && u.UserRole == ROLE_ADMIN);
                if (user != null)
                {
                    Session["AdminUser"] = user.Username;   // đánh dấu đã đăng nhập Admin

                    // Quay lại đúng trang đang muốn vào (chỉ chấp nhận link trong web mình)
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Sai tên đăng nhập / mật khẩu, hoặc tài khoản không phải Admin.");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        // GET: admin/AdminAccount/Logout
        public ActionResult Logout()
        {
            Session.Remove("AdminUser");   // chỉ xoá đăng nhập Admin, giỏ hàng Customer vẫn giữ
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}