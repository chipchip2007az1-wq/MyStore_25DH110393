using System.ComponentModel.DataAnnotations;

namespace _25DH110393_MyStore.Models.VỉewModel
{
    public class ProfileVM
    {
        // 2 trường chỉ để hiển thị, không cho sửa
        [Display(Name = "Tên đăng nhập")]
        public string Username { get; set; }

        [Display(Name = "Họ tên")]
        public string CustomerName { get; set; }

        // 3 trường cho phép sửa (theo slide)
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [StringLength(15, ErrorMessage = "Số điện thoại tối đa 15 ký tự")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string CustomerPhone { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [Display(Name = "Email")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string CustomerAddress { get; set; }
    }
}