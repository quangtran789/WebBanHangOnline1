using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;

namespace WebBanHangOnline.Areas.Admin.Controllers.Facade
{
    public class StatisticalFacade : IStatisticalFacade
    {
        private readonly ApplicationDbContext _db;

        public StatisticalFacade()
        {
            _db = new ApplicationDbContext();
        }

        public object GetStatisticalData(string fromDate, string toDate)
        {
            var query = from o in _db.Orders
                        join od in _db.OrderDetails on o.Id equals od.OrderId
                        join p in _db.Products on od.ProductId equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };

            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate >= startDate);
            }

            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate))
                              .Select(x => new
                              {
                                  Date = x.Key.Value,
                                  TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                                  TotalSell = x.Sum(y => y.Quantity * y.Price),
                              })
                              .Select(x => new
                              {
                                  Date = x.Date,
                                  DoanhThu = x.TotalSell,
                                  LoiNhuan = x.TotalSell - x.TotalBuy
                              });

            return new { Data = result };
        }
    }

}