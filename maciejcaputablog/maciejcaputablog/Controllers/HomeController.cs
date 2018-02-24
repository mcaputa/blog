using System.Diagnostics;
using ApplicationCore.Interfaces.Services;
using maciejcaputablog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }
        public IActionResult Index()
        {
            var postDomainModel= _postService.GetAllPosts();

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
