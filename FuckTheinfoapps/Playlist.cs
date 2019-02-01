namespace FuckTheinfoapps
{
    class Playlist
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public Playlist(string _Name, string _Url)
        {
            Name = _Name;
            Url = _Url;
        }
    }
}
