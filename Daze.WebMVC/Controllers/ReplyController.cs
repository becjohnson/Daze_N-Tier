﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daze.WebMVC.Controllers
{
    public class ReplyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
