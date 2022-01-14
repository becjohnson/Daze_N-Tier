using Daze.Models.Post;
using Daze.Models.Post_Models;
using Daze.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daze.WebMVC.Controllers
{
    public class PostController : Controller
    {
        [Authorize]
        private PostService CreatePostService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            return service;
        }
        // GET: Post
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userId);
            var model = new PostListItem[0];
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model)
        {
            if (ModelState.IsValid) return View(model);
            var service = CreatePostService();
            if (service.CreatePost(model))
            {
                TempData["SaveResult"] = "Your note was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Post could not be created.");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreatePostService();
            var model = svc.GetPostById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePostService();
            var detail = service.GetPostById(id);
            var model =
                new PostEdit
                {
                    PostId = detail.PostId,
                    Title = detail.Title,
                    Content = detail.Content,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PostEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.PostId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreatePostService();
            if (service.UpdatePost(model))
            {
                TempData["Save Result"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your note could not be updated.");
            return View(model);
        }
    }
}
