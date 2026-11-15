using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25DH110393_MyStore.Models.VỉewModel
{
    public class HomeProductVM
    {
        public string SearchTerm { get; set;  }
        public int PageNumber {   get; set;  }//trang hiện tại
        public int PageSize { get; set; } =10;//số sản phẩm  mỗi trang

        //danh sách nổi bật
        public List<Product> FeaturedProducts { get; set; }
        //danh sách sản phẩm đã phân trang
        public PagedList.IPagedList<Product> NewProducts { get; set; }
    }
}