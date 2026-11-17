using _25DH110393_MyStore.Models;
using PagedList;
using System.ComponentModel.DataAnnotations;

namespace _25DH110393_MyStore.Models.VỉewModel
{
    // ===== Trang Home: thống kê 1 loại hàng =====
    public class CategoryStatVM
    {
        public string CategoryName { get; set; }
        public int ProductCount { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? AvgPrice { get; set; }
    }

    // ===== Trang Khách hàng =====
    public class CustomerSearchVM
    {
        public string SearchTerm { get; set; }
        public string SortOrder { get; set; }
        public int TotalCount { get; set; }
        public IPagedList<Customer> Customers { get; set; }
    }

    // ===== Trang Đơn hàng =====
    public class AdminOrderListVM
    {
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public int TotalCount { get; set; }
        public IPagedList<Order> Orders { get; set; }
    }

    // ===== Trang Tài khoản Admin: danh sách =====
    public class AdminUserListVM
    {
        public string SearchTerm { get; set; }
        public IPagedList<User> Users { get; set; }
    }

    // ===== Trang Tài khoản Admin: thêm mới =====
    public class AdminUserCreateVM
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [StringLength(255)]
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(50, ErrorMessage = "Mật khẩu tối đa 50 ký tự")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [Display(Name = "Xác nhận mật khẩu")]
        public string ConfirmPassword { get; set; }
    }

    // ===== Trang Tài khoản Admin: đổi mật khẩu =====
    public class AdminChangePasswordVM
    {
        public string Username { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [StringLength(50, ErrorMessage = "Mật khẩu tối đa 50 ký tự")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu mới")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu mới")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        [Display(Name = "Xác nhận mật khẩu mới")]
        public string ConfirmNewPassword { get; set; }
    }
}