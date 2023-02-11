namespace LiftOff_Project.Models
{
    public class Song
    {
        public int SongId { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Year { get; set; }

        public Song(string artist, string title, string genre, string year)
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
