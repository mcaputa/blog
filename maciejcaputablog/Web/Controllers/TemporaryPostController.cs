using ApplicationCore.Interfaces.Services;
using ApplicationCore.Models.DomainModels;
using ApplicationCore.Models.StorageModels;
using AutoMapper;
using maciejcaputablog.InputModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class TemporaryPostController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPostService _postService;

        public TemporaryPostController(IMapper mapper, IPostService postService)
        {
            _mapper = mapper;
            _postService = postService;
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
            var postDomainModel = new PostDomainModel()
            {
                PostStorageModel = _mapper.Map<PostInputModel, PostStorageModel>(model)
            };
            _postService.CreatePost(postDomainModel);
                
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Read(int postId)
        {
            var post = _postService.GetPost(postId);

            var postViewModel = new PostViewModel()
            {
                PostDomainModel = post
            };

            return View(postViewModel);
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