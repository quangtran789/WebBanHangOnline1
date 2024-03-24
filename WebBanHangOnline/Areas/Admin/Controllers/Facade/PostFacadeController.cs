using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanHangOnline.Areas.Admin.Controllers.Facade;
using WebBanHangOnline.Models;
using WebBanHangOnline.Models.EF;

namespace WebBanHangOnline.Areas.Admin.Controllers
{
    public class PostFacadeController : Controller
    {
        private PostFacade postFacade = new PostFacade();

        // GET: Admin/Post
        public ActionResult Index()
        {
            var items = postFacade.GetAllPosts();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {
            if (ModelState.IsValid)
            {
                postFacade.AddPost(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var item = postFacade.GetPostById(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
        {
            if (ModelState.IsValid)
            {
                postFacade.EditPost(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            bool success = postFacade.DeletePost(id);
            return Json(new { success = success });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            bool success = postFacade.TogglePostIsActive(id);
            var item = postFacade.GetPostById(id);
            return Json(new { success = success, isActive = item.IsActive });
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            bool success = postFacade.DeleteAllPosts(ids);
            return Json(new { success = success });
        }
    }

    
}
