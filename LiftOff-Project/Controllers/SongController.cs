using LiftOff_Project.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LiftOff_Project.Models;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace LiftOff_Project.Controllers
{
    public class SongController : Controller
    {
        private ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public SongController(ApplicationDbContext dbContext, IConfiguration configuration)
        {
            _context = dbContext;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            List<Song> songs = _context.Songs.ToList();
            return View(songs);
        }

        private List<Song> GetSongs()
        {
            List<Song> songs = new List<Song>();

            string connectionString = _configuration.GetConnectionString("DeafaultConnection");

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM songs", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            songs.Add(new Song
                            {
                                SongId = reader.GetInt32("SongId"),
                                Artist = reader.GetString("Artist"),
                                Title = reader.GetString("Title"),
                                Link = reader.GetString("Link"),
                                Lyrics = reader.GetString("Lyrics")
                            });
                        }
                    }
                }
            }
            return songs;
        }
    }
}