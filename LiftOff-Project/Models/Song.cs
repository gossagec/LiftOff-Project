namespace LiftOff_Project.Models
{
    public class Song
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public int SongId { get; set; }

        public Song(string artist, string title, string genre, int year)
        {
            Artist = artist;
            Title = title;
            Genre = genre;
            Year = year;
        }
        public Song()
        {
        }
    }
}
