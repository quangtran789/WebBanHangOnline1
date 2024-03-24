using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.Factory
{
    public class ProductCategoryFactory : IProductCategoryFactory
    {
        public ProductCategory CreateProductCategory()
        {
            return new ProductCategory();
        }
    }

}