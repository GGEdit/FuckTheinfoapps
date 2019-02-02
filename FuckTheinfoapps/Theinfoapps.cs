using Codeplex.Data;
using System;
using System.Collections.Generic;

namespace FuckTheinfoapps
{
    class Theinfoapps
    {
        private HttpClient httpClient;
        private HttpClientHeader clientHeader;
        private HttpClientCookie clientCookie;

        private string getJsonUri;
        private dynamic obj;
        private string has_more;
        private string idfa;

        public Theinfoapps()
        {
            httpClient = new HttpClient();
            clientHeader = new HttpClientHeader();
            clientCookie = new HttpClientCookie();
            clientCookie.SetCookie(new Uri("https://theinfoapps.com"), "sessionid", "sug3hctj326h6cex1xuwa9mc52judn0f");
        }

        public Theinfoapps(string sessionId)
        {
            httpClient = new HttpClient();
            clientCookie.SetCookie(new Uri("https://theinfoapps.com"), "sessionid", sessionId);
        }

        public Theinfoapps(string sessionId, string _idfa)
        {
            httpClient = new HttpClient();
            clientCookie.SetCookie(new Uri("https://theinfoapps.com"), "sessionid", sessionId);
            idfa = _idfa;
        }

        public dynamic GetSongObj(string songName, int sCount)
        {
            httpClient.RequestUri = $"https://theinfoapps.com/myfm/search/v2/?appid=com.tenormusicfm.ios.fm&page_no={sCount}&query={songName}";
            getJsonUri = httpClient.Get(clientHeader, clientCookie);
            obj = DynamicJson.Parse(getJsonUri);
            if (!this.ExistsSongObject(obj))
            {
                return null;
            }
            return obj;
        }

        private bool ExistsSongObject(dynamic _obj)
        {
            has_more = _obj.data.has_more.ToString();
            if (has_more != "True")
                return false;

            return true;
        }

        public dynamic GetPlaylistObj(string uid)
        {
            httpClient.RequestUri = $"https://theinfoapps.com/myfm/user/profile/?uid={uid}";
            getJsonUri = httpClient.Get(clientHeader, clientCookie);
            obj = DynamicJson.Parse(getJsonUri);
            if (!ExistsPlaylistObject(obj))
            {
                return null;
            }

            return obj;
        }

        private bool ExistsPlaylistObject(dynamic _obj)
        {
            has_more = _obj.data.song_lists.ToString();
            if (has_more == "[]")
                return false;

            return true;
        }

        public dynamic GetSongObjByPlayList(string songListid)
        {
            httpClient.RequestUri = $"https://theinfoapps.com/myfm/songlist/detail/?client_send_version=-1&song_list_id={songListid}";
            var result = httpClient.Get(clientHeader, clientCookie);

            obj = DynamicJson.Parse(result);
            if (!ExistsSongObjByPlayList(obj))
            {
                return null;
            }
            return obj;
        }

        private bool ExistsSongObjByPlayList(dynamic _obj)
        {
            //Cookie Check
            has_more = _obj.data.ToString();
            if (has_more == "null")
                return false;

            //ListId Check
            has_more = _obj.data.status.ToString();
            if (has_more == "1")
                return false;

            return true;
        }

        private bool IsSyncDLCountSucceeded(dynamic _obj)
        {
            string json = _obj.data.n.ToString();
            if (json != "1")
                return false;

            return true;
        }

        public void SyncDLCount(string item_id, string optime, string type, string value)
        {
            var dic = new Dictionary<string, string>();
            dic["sync_infos[][item_id]"] = item_id;
            dic["sync_infos[][optime]"] = optime;
            dic["sync_infos[][type]"] = type;
            dic["sync_infos[][value]"] = value;

            httpClient.RequestUri = $"https://theinfoapps.com/myfm/dlquota/sync/?idfa={idfa}";
            clientHeader.AddParam(dic);
            clientHeader.ContentType = "application/x-www-form-urlencoded";
            var result = httpClient.Post(clientHeader, clientCookie);

            obj = DynamicJson.Parse(result);
            if (!IsSyncDLCountSucceeded(obj))
                throw new ArgumentException();
        }
    }
}
