using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Areas.Admin.Controllers.Facade
{
    public interface IStatisticalFacade
    {
        object GetStatisticalData(string fromDate, string toDate);
    }

}