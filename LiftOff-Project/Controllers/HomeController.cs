using LiftOff_Project.Data;
using LiftOff_Project.Migrations;
using LiftOff_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.CodeAnalysis.Options;
using Microsoft.VisualBasic;

namespace LiftOff_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var songs = from s in _context.Songs
                        select s;

            if (!string.IsNullOrEmpty(searchString))
            {
                songs = songs.Where(p => p.Artist.Contains(searchString) || s.Title.Contains(searchString));
            }

            return View(await songs.ToListAsync());
        }

        private IActionResult SortEra()
        {
            var songs = from s in _context.Songs
                        select s;
            if (songs.Year => 1970 || songs.Year < 1980)
            {
                
            }
            return View();
        }
        
        /*public async Task<IActionResult> EraChosen()
        {
            var songs = from s in _context.Songs
                        select s;
            if ()
            {
                songs = songs.Where(s => s.Year.Equals(1970));
            }
            return View(await songs.ToListAsync());
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}