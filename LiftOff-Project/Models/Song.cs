namespace LiftOff_Project.Models
{
    public class Song
    {
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Lyrics { get; set; }
        public int SongId { get; set; }

        public Song(string artist, string title, string link, string lyrics)
        {
            Artist = artist;
            Title = title;
            Link = link;
            Lyrics = lyrics;
        }
        public Song()
        {
        }
    }
}
