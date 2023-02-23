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
        object[] _eras =
            {
                new { key = 1, name = "1970's", start = 1970, end = 1979 },
                new { key = 2, name = "1980's", start = 1980, end = 1989 },
                new { key = 3, name = "1990's", start = 1990, end = 1999 },
                new { key = 4, name = "2000's", start = 2000, end = 2009 },
                new { key = 5, name = "2010's", start = 2010, end = 2019 }
            };

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
                songs = songs.Where(p => p.Artist.Contains(searchString) || p.Title.Contains(searchString));
            }

            return View(await songs.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> EraChosen(string yearString)
        {
            var songs = from s in _context.Songs
                        select s;

            if (!string.IsNullOrEmpty(yearString))
            {
                songs = songs.Where(p => p.Year.ToString().Contains(yearString));
            }

            return View(await songs.ToListAsync());
        }

        /*public async Task<IActionResult> EraChosen()
        {
            var songs = from s in _context.Songs
                        select s;
            
            songs = songs.Where(p => p.Year >= _eras[1].start && p.Year < _eras[1].end);

            return View(await songs.ToListAsync());
        }*/

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}