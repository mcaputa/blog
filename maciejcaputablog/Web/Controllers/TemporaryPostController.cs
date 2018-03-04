﻿using AutoMapper;

using Core.Interfaces.Services;
using Core.Models.DomainModels;
using Core.Models.StorageModels;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Web.ViewModels;

namespace Web.Controllers
{
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

            var postDomainModel = new PostDomainModel(post);
            
            this.postService.CreatePost(postDomainModel);
                
            return this.RedirectToAction("Index", "Home");
        }
        
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Read(int postId)
        {
            var post = this.postService.GetPost(postId);

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