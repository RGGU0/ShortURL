using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortURL.Data;
using ShortURL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var values = _context.Links.ToList();
            return View(values);
        }

        public IActionResult AddLink(Links _NewLink)
        {
            var _Links = new Links
            {
                LongUrl = _NewLink.LongUrl,
                Created = 1,
                ShortUrl = "https://localhost:44324/Home/" + _NewLink.GetHash(),
                Clicks = 2
            };
            if((_NewLink.LongUrl != null))
            {
                _context.Links.Add(_Links);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                return View(_Links);
            }
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
