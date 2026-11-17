using _25DH110393_MyStore.Models.VỉewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25DH110393_MyStore.Models.Vỉewmodel
{
    public class ProfileInfoVM
    {
        public ProfileVM Current { get; set; }          // thông tin đang lưu trong DB (khối bên trái)
        public ProfileVM Profile { get; set; }          // form Cập nhật thông tin
        public ChangePasswordVM Password { get; set; }  // form Đổi mật khẩu
    }
}