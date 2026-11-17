using _25DH110393_MyStore.Models;
using System.Collections.Generic;

namespace _25DH110393_MyStore.Models.VỉewModel
{
    public class MyOrderVM
    {
        // Các trạng thái đơn hàng (theo slide)
        public const string CHO_THANH_TOAN = "Chờ thanh toán";
        public const string DANG_XU_LY = "Đang xử lý";
        public const string DANG_VAN_CHUYEN = "Đang vận chuyển";
        public const string DA_GIAO = "Đã giao";
        public const string DA_HUY = "Đã hủy";

        // Thứ tự các tab
        public static readonly string[] Statuses =
            { CHO_THANH_TOAN, DANG_XU_LY, DANG_VAN_CHUYEN, DA_GIAO, DA_HUY };

        public string Status { get; set; }                  // tab đang chọn (rỗng = Tất cả)
        public string Search { get; set; }                  // từ khoá tìm kiếm
        public List<Order> Orders { get; set; }             // danh sách đơn sau khi lọc
        public Dictionary<string, int> StatusCounts { get; set; } // số đơn mỗi trạng thái (hiện trên tab)
        public int TotalCount { get; set; }                 // tổng số đơn
    }
}