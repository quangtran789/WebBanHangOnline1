using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBanHangOnline.Areas.Admin.Controllers.Decorator
{
    public class LoggingOrderControllerDecorator : OrderController
    {
        private OrderController _orderController;

        public LoggingOrderControllerDecorator(OrderController orderController)
        {
            _orderController = orderController;
        }

        public override ActionResult Index(int? page)
        {
            Log("Index action is called.");
            return _orderController.Index(page);
        }

        private void Log(string message)
        {
            // Ghi nhật ký vào hệ thống
            Console.WriteLine($"[Log]: {message}");
        }
    }
}