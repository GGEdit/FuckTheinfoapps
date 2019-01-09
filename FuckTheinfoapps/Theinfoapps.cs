using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace FuckTheinfoapps
{
    class Theinfoapps
    {
        private Cookie cookie;
        private Uri uri;
        private CookieContainer cookieContainer;
        private HttpWebRequest getSongObjByPlayListReq, syncDLCountReq;
        private WebResponse getSongObjByPlayListRes, syncDLCountRes;
        private Stream getSongObjByPlayListStream, syncDLCountReqStream, syncDLCountStream;
        private WebClient client;
        private string getJsonUri;
        private dynamic obj;
        private string has_more;
        private string idfa;

        public Theinfoapps()
        {
            client = new WebClient();
            cookie = new Cookie("sessionid", "sug3hctj326h6cex1xuwa9mc52judn0f");
            uri = new Uri("https://theinfoapps.com");
            cookieContainer = new CookieContainer();
            cookieContainer.Add(uri, cookie);
        }

        public Theinfoapps(string sessionId)
        {
            client = new WebClient();
            cookie = new Cookie("sessionid", sessionId);
            uri = new Uri("https://theinfoapps.com");
            cookieContainer = new CookieContainer();
            cookieContainer.Add(uri, cookie);
        }

        public Theinfoapps(string sessionId, string _idfa)
        {
            client = new WebClient();
            cookie = new Cookie("sessionid", sessionId);
            uri = new Uri("https://theinfoapps.com");
            cookieContainer = new CookieContainer();
            cookieContainer.Add(uri, cookie);
            idfa = _idfa;
        }

        public dynamic GetSongObj(string songName, int sCount)
        {
            getJsonUri = client.DownloadString($"https://theinfoapps.com/myfm/search/v2/?appid=com.tenormusicfm.ios.fm&page_no={sCount}&query={songName}");
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
            getJsonUri = client.DownloadString($"https://theinfoapps.com/myfm/user/profile/?uid={uid}");
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
            getSongObjByPlayListReq = (HttpWebRequest)WebRequest.Create($"https://theinfoapps.com/myfm/songlist/detail/?client_send_version=-1&song_list_id={songListid}");
            getSongObjByPlayListReq.Method = "GET";
            getSongObjByPlayListReq.CookieContainer = cookieContainer;
            getSongObjByPlayListRes = getSongObjByPlayListReq.GetResponse();

            getSongObjByPlayListStream = getSongObjByPlayListRes.GetResponseStream();
            var streamReader = new StreamReader(getSongObjByPlayListStream);
            obj = DynamicJson.Parse(streamReader.ReadToEnd());
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
            string param = string.Empty;
            var dic = new Dictionary<string, string>();
            dic["sync_infos[][item_id]"] = item_id;
            dic["sync_infos[][optime]"] = optime;
            dic["sync_infos[][type]"] = type;
            dic["sync_infos[][value]"] = value;

            foreach (string key in dic.Keys)
                param += $"{key}={dic[key]}&";

            byte[] data = Encoding.ASCII.GetBytes(param);
            syncDLCountReq = (HttpWebRequest)WebRequest.Create($"https://theinfoapps.com/myfm/dlquota/sync/?idfa={idfa}");
            syncDLCountReq.Method = "POST";
            syncDLCountReq.CookieContainer = cookieContainer;
            syncDLCountReq.ContentType = "application/x-www-form-urlencoded";
            syncDLCountReq.ContentLength = data.Length;

            syncDLCountReqStream = syncDLCountReq.GetRequestStream();
            syncDLCountReqStream.Write(data, 0, data.Length);

            syncDLCountRes = syncDLCountReq.GetResponse();
            syncDLCountStream = syncDLCountRes.GetResponseStream();
            var reader = new StreamReader(syncDLCountStream, Encoding.GetEncoding("Shift_JIS"));
            obj = DynamicJson.Parse(reader.ReadToEnd());
            if (!IsSyncDLCountSucceeded(obj))
                throw new ArgumentException();
        }
    }
}
