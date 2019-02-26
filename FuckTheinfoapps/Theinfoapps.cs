using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuckTheinfoapps
{
    class Theinfoapps
    {
        private HClient client;
        private HClientHeader clientHeader;
        private HClientCookie clientCookie;

        private string getJsonUri;
        private dynamic obj;
        private string has_more;
        private string idfa;

        public Theinfoapps()
        {
            client = new HClient();
            clientHeader = new HClientHeader();
            clientCookie = new HClientCookie();
            clientCookie.SetCookie("sessionid", "sug3hctj326h6cex1xuwa9mc52judn0f");
        }

        public Theinfoapps(string sessionId)
        {
            client = new HClient();
            clientCookie.SetCookie("sessionid", sessionId);
        }

        public Theinfoapps(string sessionId, string _idfa)
        {
            client = new HClient();
            clientCookie.SetCookie("sessionid", sessionId);
            idfa = _idfa;
        }

        public async Task<dynamic> GetSongObj(string songName, int sCount)
        {
            client.RequestUri = $"https://theinfoapps.com/myfm/search/v2/?appid=com.tenormusicfm.ios.fm&page_no={sCount}&query={songName}";
            getJsonUri = await client.Get(clientCookie, clientHeader);
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

        public async Task<dynamic> GetPlaylistObj(string uid)
        {
            client.RequestUri = $"https://theinfoapps.com/myfm/user/profile/?uid={uid}";
            getJsonUri = await client.Get(clientCookie, clientHeader);
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

        public async Task<dynamic> GetSongObjByPlayList(string songListid)
        {
            client.RequestUri = $"https://theinfoapps.com/myfm/songlist/detail/?client_send_version=-1&song_list_id={songListid}";
            var result = await client.Get(clientCookie, clientHeader);

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

        public async void SyncDLCount(string item_id, string optime, string type, string value)
        {
            var dic = new Dictionary<string, string>();
            dic["sync_infos[][item_id]"] = item_id;
            dic["sync_infos[][optime]"] = optime;
            dic["sync_infos[][type]"] = type;
            dic["sync_infos[][value]"] = value;

            client.RequestUri = $"https://theinfoapps.com/myfm/dlquota/sync/?idfa={idfa}";
            clientHeader.AddParam(dic);
            clientHeader.ContentType = "application/x-www-form-urlencoded";
            var result = await client.Post(clientCookie, clientHeader);

            obj = DynamicJson.Parse(result);
            if (!IsSyncDLCountSucceeded(obj))
                throw new ArgumentException();
        }
    }
}