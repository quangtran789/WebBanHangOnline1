using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers.Facade
{
    public class PostFacade
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Posts> GetAllPosts()
        {
            return db.Posts.ToList();
        }

        public Posts GetPostById(int id)
        {
            return db.Posts.Find(id);
        }

        public void AddPost(Posts model)
        {
            model.CategoryId = 3;
            model.CreatedDate = DateTime.Now;
            model.ModifierDate = DateTime.Now;
            model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
            db.Posts.Add(model);
            db.SaveChanges();
        }

        public void EditPost(Posts model)
        {
            model.ModifierDate = DateTime.Now;
            model.Alias = WebBanHangOnline.Models.Common.Filter.FilterChar(model.Title);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public bool DeletePost(int id)
        {
            var item = db.Posts.Find(id);
            if (item != null)
            {
                db.Posts.Remove(item);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool TogglePostIsActive(int id)
        {
            var item = db.Posts.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteAllPosts(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if (items != null && items.Any())
                {
                    foreach (var item in items)
                    {
                        var obj = db.Posts.Find(Convert.ToInt32(item));
                        db.Posts.Remove(obj);
                    }
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}