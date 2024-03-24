using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Data
{
    public sealed class CategorySingleton
    {
        private static readonly object lockObject = new object();
        private static CategorySingleton instance;
        private static ApplicationDbContext db;

        private CategorySingleton()
        {
            db = new ApplicationDbContext();
        }

        public static CategorySingleton Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new CategorySingleton();
                    }
                    return instance;
                }
            }
        }

        public ApplicationDbContext GetDbContext()
        {
            return db;
        }
    }
}