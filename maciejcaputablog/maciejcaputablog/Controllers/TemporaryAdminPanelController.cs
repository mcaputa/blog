using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace maciejcaputablog.Controllers
{
    public class TemporaryAdminPanelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}