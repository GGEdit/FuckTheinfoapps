using Codeplex.Data;
using System.Net;

namespace FuckTheinfoapps
{
    class Theinfoapps
    {
        private WebClient wc;
        private string getJsonUri;
        private dynamic obj;
        private string has_more;

        public Theinfoapps()
        {
            wc = new WebClient();
        }

        public dynamic GetObject(string songName, int sCount)
        {
            getJsonUri = wc.DownloadString($"https://theinfoapps.com/myfm/search/v2/?appid=com.tenormusicfm.ios.fm&page_no={sCount}&query={songName}");
            obj = DynamicJson.Parse(getJsonUri);
            if (!this.Exists(obj))
            {
                return null;
            }
            return obj;
        }

        private bool Exists(dynamic _obj)
        {
            has_more = _obj.data.has_more.ToString();
            if (has_more != "True")
                return false;

            return true;
        }
    }
}
