using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _25DH110393_MyStore.Models.VỉewModel
{
    public class ProductDetailsVM
    {
        public Product product { get; set; }
        public int quanity { get; set; } = 1;
        public decimal estimatedValue { get; set; }//tính giá trị tạm thời
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 3;


        public List<Product> RelatedProducts { get; set; }

        public PagedList.IPagedList<Product> TopProducts
        {
            get; set;
        }
    }
}