﻿using Microsoft.AspNetCore.Mvc;

namespace ProjectRestaurant.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class HomeController : Controller
    {
        [HttpGet("/Admin/Anasayfa")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
