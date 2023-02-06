using LiftOff_Project.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LiftOff_Project.Models;
using System.Linq;

namespace LiftOff_Project.Controllers
{
    public class SongController : Controller
    {
        private SongDbContext context;
        public SongController(SongDbContext dbContext)
        {
            context = dbContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Song> songs = context.Songs.ToList();
            return View(songs);
        }
    }
}
