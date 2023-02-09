using LiftOff_Project.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LiftOff_Project.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace LiftOff_Project.Controllers
{
    public class SongController : Controller
    {
        private ApplictaionDbContext context;
        public SongController(ApplictaionDbContext dbContext)
        {
            context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            return View(await context.Songs.ToListAsync());
        }
        
        [HttpGet]
        [Route("/Song/details")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var songs = await context.Songs
                .FirstOrDefaultAsync(m => m.SongId == id);
            if (songs == null)
            {
                return NotFound();
            }
            return View(songs);
        }

        [HttpGet]
        
        public async Task<IActionResult> Search(string searchString)
        {
            var songs = from m in context.Songs
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                songs = songs.Where(s => s.Title.Contains(searchString));
            }
            
            return View(await songs.ToListAsync());
        }
    }
}
