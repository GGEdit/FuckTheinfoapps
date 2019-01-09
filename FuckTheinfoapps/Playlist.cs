namespace FuckTheinfoapps
{
    class Playlist
    {
        private string pName;
        private string pUrl;

        public Playlist(string _Name, string _Url)
        {
            pName = _Name;
            pUrl = _Url;
        }

        public string Name
        {
            get
            {
                return pName;
            }
            set
            {
                pName = value;
            }
        }

        public string Url
        {
            get
            {
                return pUrl;
            }
            set
            {
                pUrl = value;
            }
        }
    }
}
