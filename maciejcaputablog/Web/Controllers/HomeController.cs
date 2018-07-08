using System.Diagnostics;
using Core.Interfaces.Services;
using maciejcaputablog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    using System.Text;

    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }

        public IActionResult Index()
        {
            var allPostsDomainModel = this.postService.GetAllPosts();

            var mainPageViewModel = new MainPageViewModel()
            {
                AllPostsDomainModel = allPostsDomainModel
            };

            return View(mainPageViewModel);
        }
        
        [HttpGet]
        [ResponseCache(Duration = 2592000)]
        [Route("robots.txt")]
        public ContentResult RobotsText()
        {
            StringBuilder stringBuilder = new StringBuilder();
        
            stringBuilder.AppendLine("User-agent: *");
            stringBuilder.AppendLine("Disallow: ");
        
            return this.Content(stringBuilder.ToString(), "text/plain", Encoding.UTF8);
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
