﻿using Microsoft.AspNetCore.Mvc;

namespace WildPaws.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
