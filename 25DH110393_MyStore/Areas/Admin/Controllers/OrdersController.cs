using _25DH110393_MyStore.Models;
using _25DH110393_MyStore.Models.VỉewModel;
using PagedList;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace _25dh230038_mystore.Areas.Admin.Controllers
{
    [AdminAuthorize]
    public class OrdersController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // GET: admin/Orders  |  admin/Orders?customerId=3  |  admin/Orders?status=Đang xử lý
        public ActionResult Index(int? customerId, string status, int? page)
        {
            IQueryable<Order> orders = db.Orders.Include(o => o.Customer);
            string customerName = null;

            // Đơn hàng của 1 khách cụ thể (bấm nút "Đơn hàng" ở trang Khách hàng)
            if (customerId.HasValue)
            {
                orders = orders.Where(o => o.CustomerID == customerId.Value);
                customerName = db.Customers.Where(c => c.CustomerID == customerId.Value)
                                           .Select(c => c.CustomerName).FirstOrDefault();
            }

            // Lọc theo trạng thái
            if (!string.IsNullOrEmpty(status))
            {
                orders = orders.Where(o => o.OrderStatus == status);
            }

            orders = orders.OrderByDescending(o => o.OrderDate).ThenByDescending(o => o.OrderID);

            var model = new AdminOrderListVM
            {
                CustomerId = customerId,
                CustomerName = customerName,
                Status = status,
                TotalCount = orders.Count(),
                Orders = orders.ToPagedList(page ?? 1, 10)
            };
            return View(model);
        }

        // GET: admin/Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var order = db.Orders.Include(o => o.Customer)
                                 .Include("OrderDetails.Product")
                                 .SingleOrDefault(o => o.OrderID == id);
            if (order == null) return HttpNotFound();
            return View(order);
        }

        // POST: admin/Orders/UpdateStatus/5 — đổi trạng thái đơn hàng
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateStatus(int id, string orderStatus)
        {
            var order = db.Orders.Find(id);
            if (order == null) return HttpNotFound();

            if (!MyOrderVM.Statuses.Contains(orderStatus))
            {
                TempData["Error"] = "Trạng thái không hợp lệ.";
            }
            else
            {
                order.OrderStatus = orderStatus;
                db.SaveChanges();
                TempData["Success"] = "Đã cập nhật trạng thái đơn #" + id + " thành \"" + orderStatus + "\".";
            }
            return RedirectToAction("Details", new { id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}