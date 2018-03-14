using AutoMapper;

using Core.Interfaces.Services;
using Core.Models.DomainModels;
using Core.Models.StorageModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Web.ViewModels;

namespace Web.Controllers
{
    using System.Security.Claims;

    using Common.Consts;
    using Common.Extensions;

    using Web.InputModels;

    [Authorize]
    public class TemporaryPostController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPostService postService;

        public TemporaryPostController(
            IMapper mapper,
            IPostService postService)
        {
            this.mapper = mapper;
            this.postService = postService;
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostInputModel model)
        {
            var post = this.mapper.Map<PostInputModel, PostStorageModel>(model);
            post.FriendlyTitleUrl = post.Title.GetFriendlyTitle(true);

            post.UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var postDomainModel = new PostDomainModel(post);
            
            this.postService.CreatePost(postDomainModel);
                
            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Route("{friendlyTitle}", Name = RouteNames.GetPostRoute)]
        [AllowAnonymous]
        public ActionResult Read(string friendlyTitle)
        {
            var post = this.postService.GetPost(friendlyTitle);

            var postViewModel = new PostViewModel()
            {
                PostDomainModel = post
            };

            return this.View(postViewModel);
        }

        [HttpGet]
        public ActionResult Update()
        {
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Update(object bleh)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            return RedirectToAction("Index", "Home");
        }

    }
}