using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList.Mvc;
namespace _25DH110393_MyStore.Models.VỉewModel
{
    public class ProductSearchVM
    {
        //search theo tên sp
        public string SearchTerm { get; set;  }



        //theo giá
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }


        //thứ tự sắp xếp
        public string SortOrder { get; set; }

        //hỗ trợ phân trang
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public PagedList.IPagedList<Product> Products { get; set; }


        //danh sách sp thỏa điều kiện
        //public List<Products> Products{get;set;}
    }
}