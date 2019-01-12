using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

class HttpClient
{
    private HttpWebRequest request;
    private WebResponse response;
    private Cookie cookie;
    private CookieContainer cookieContainer;
    private Dictionary<string, string> postKeyValuePairs, headersKeyValuePairs;
    private string param;
    private Stream stream;
    private StreamReader reader;

    public Uri RequestUri;
    public string ContentType;
    public string Accept;
    public string Referer;
    public string UserAgent;
    public string Expect;

    public HttpClient()
    {
    }

    public HttpClient(Dictionary<string, string> _postKeyValuePairs)
    {
        postKeyValuePairs = new Dictionary<string, string>(_postKeyValuePairs);
    }

    public void SetPostParam(Dictionary<string, string> _postKeyValuePairs)
    {
        postKeyValuePairs = new Dictionary<string, string>(_postKeyValuePairs);
    }

    public void SetCookie(Uri _uri, string _key, string _value)
    {
        if (_uri == null)
            return;

        if (_key == "" || _value == "")
            return;

        cookieContainer = new CookieContainer();
        cookie = new Cookie(_key, _value);
        cookieContainer.Add(_uri, cookie);
    }

    public void SetCookie(Uri _uri, Dictionary<string, string> _cookieKeyValuePairs)
    {
        if (_uri == null)
            return;

        if (_cookieKeyValuePairs != null)
        {
            cookieContainer = new CookieContainer();
            foreach (var pair in _cookieKeyValuePairs)
            {
                cookie = new Cookie(pair.Key, pair.Value);
                cookieContainer.Add(_uri, cookie);
            }
        }
    }

    public void SetHeader(Dictionary<string, string> _headersKeyValuePairs)
    {
        if (_headersKeyValuePairs != null)
            headersKeyValuePairs = new Dictionary<string, string>(_headersKeyValuePairs);
    }

    public string Get()
    {
        if (RequestUri == null)
            return null;

        try
        {
            request = (HttpWebRequest)WebRequest.Create(RequestUri);
            request.Method = "GET";
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;

            if (headersKeyValuePairs != null)
                foreach (var pair in headersKeyValuePairs)
                    request.Headers.Add(pair.Key, pair.Value);

            request.Accept = Accept;
            request.ContentType = ContentType;
            request.Referer = Referer;
            request.UserAgent = UserAgent;
            request.Expect = Expect;

            response = request.GetResponse();
            stream = response.GetResponseStream();
            reader = new StreamReader(stream);

            return reader.ReadToEnd();
        }
        catch
        {
            return null;
        }
    }

    public string Post()
    {
        if (RequestUri == null)
            return null;

        try
        {
            request = (HttpWebRequest)WebRequest.Create(RequestUri);
            request.Method = "POST";
            if (cookieContainer != null)
                request.CookieContainer = cookieContainer;

            if (headersKeyValuePairs != null)
                foreach (var pair in headersKeyValuePairs)
                    request.Headers.Add(pair.Key, pair.Value);

            param = "";
            if (postKeyValuePairs != null)
                foreach (string key in postKeyValuePairs.Keys)
                    param += $"{key}={postKeyValuePairs[key]}&";
            byte[] data = Encoding.ASCII.GetBytes(param);

            request.Accept = Accept;
            request.ContentType = ContentType;
            request.Referer = Referer;
            request.UserAgent = UserAgent;
            request.Expect = Expect;
            request.ContentLength = data.Length;
            stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);

            response = request.GetResponse();
            stream = response.GetResponseStream();
            reader = new StreamReader(stream, Encoding.GetEncoding("Shift_JIS"));

            return reader.ReadToEnd();
        }
        catch
        {
            return null;
        }
    }
}
