﻿using System.Diagnostics;
using Core.Interfaces.Services;
using maciejcaputablog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            var postDomainModel= this.postService.GetAllPosts();

            var mainPageViewModel = new MainPageViewModel()
            {
                PostStorageModels =  postDomainModel.PostStorageModels
            };

            return View(mainPageViewModel);
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult WhyIsSoEmptyHere()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
