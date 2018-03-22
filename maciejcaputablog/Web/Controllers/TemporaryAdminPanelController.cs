using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class TemporaryAdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}