using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.Prototype
{
    public interface IProductPrototype
    {
        Product Clone();
    }

}