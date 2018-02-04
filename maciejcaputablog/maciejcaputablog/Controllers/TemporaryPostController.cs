using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using maciejcaputablog.DomainModels;
using maciejcaputablog.InputModels;
using maciejcaputablog.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace maciejcaputablog.Controllers
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
            var postDomainModel = _mapper.Map<PostInputModel, PostDomainModel>(model);
            _postService.CreatePost(postDomainModel);
                
            return RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Read(int postId)
        {
            var postViewModel = _postService.GetPost(postId);
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