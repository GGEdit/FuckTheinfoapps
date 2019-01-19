using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

class HttpClientHelper
{
    public enum Method
    {
        GET,
        POST
    }
}

class HttpClient
{
    private HttpWebRequest request;
    private HttpWebResponse response;
    private Cookie cookie;
    private CookieContainer cookieContainer;
    private Dictionary<string, string> postKeyValuePairs, headersKeyValuePairs;
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
        postKeyValuePairs = new Dictionary<string, string>();
        headersKeyValuePairs = new Dictionary<string, string>();
    }

    public HttpClient(Dictionary<string, string> _postKeyValuePairs)
    {
        postKeyValuePairs = new Dictionary<string, string>(_postKeyValuePairs);
    }

    //Parameter
    public void SetParam(Dictionary<string, string> _postKeyValuePairs)
    {
        postKeyValuePairs = new Dictionary<string, string>(_postKeyValuePairs);
    }

    public void AddParam(Dictionary<string, string> _postKeyValuePairs)
    {
        foreach (var data in _postKeyValuePairs)
            postKeyValuePairs.Add(data.Key, data.Value);
    }

    public void AddParam(string _key, string _value)
    {
        postKeyValuePairs.Add(_key, _value);
    }

    //Cookie
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

    public CookieCollection GetCookies(Uri _uri)
    {
        return request.CookieContainer.GetCookies(_uri);
    }

    public CookieCollection GetResponseCookies()
    {
        if (response == null)
            return null;

        return response.Cookies;
    }

    //Header
    public void SetHeader(Dictionary<string, string> _headersKeyValuePairs)
    {
        if (_headersKeyValuePairs != null)
            headersKeyValuePairs = new Dictionary<string, string>(_headersKeyValuePairs);
    }

    public void AddHeader(Dictionary<string, string> _headersKeyValuePairs)
    {
        if (_headersKeyValuePairs != null)
            foreach (var data in _headersKeyValuePairs)
                headersKeyValuePairs.Add(data.Key, data.Value);
    }

    public void AddHeader(string _key, string _value)
    {
        headersKeyValuePairs.Add(_key, _value);
    }

    //HttpWebRequest
    private HttpWebRequest CreateInstance(Uri _requestUri, string _method, CookieContainer _cookieContainer, Dictionary<string, string> _headersKeyValuePairs)
    {
        HttpWebRequest httpWebRequest;
        httpWebRequest = (HttpWebRequest)WebRequest.Create(_requestUri);
        httpWebRequest.Method = _method;

        if (_cookieContainer != null)
            httpWebRequest.CookieContainer = _cookieContainer;

        if (_headersKeyValuePairs != null)
            foreach (var pair in _headersKeyValuePairs)
                httpWebRequest.Headers.Add(pair.Key, pair.Value);

        return httpWebRequest;
    }

    private byte[] GetParamByte(Dictionary<string, string> _KeyValuePairs)
    {
        byte[] pByte;
        string param = "";
        if (_KeyValuePairs != null)
            foreach (string key in _KeyValuePairs.Keys)
                param += $"{key}={_KeyValuePairs[key]}&";
        pByte = Encoding.ASCII.GetBytes(param);

        return pByte;
    }

    public string Get()
    {
        if (RequestUri == null)
            return null;

        try
        {
            request = CreateInstance(RequestUri, "GET", cookieContainer, headersKeyValuePairs);
            request.Accept = Accept;
            request.ContentType = ContentType;
            request.Referer = Referer;
            request.UserAgent = UserAgent;
            request.Expect = Expect;

            response = (HttpWebResponse)request.GetResponse();
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
            request = CreateInstance(RequestUri, "POST", cookieContainer, headersKeyValuePairs);
            byte[] pByte = GetParamByte(postKeyValuePairs);

            request.Accept = Accept;
            request.ContentType = ContentType;
            request.Referer = Referer;
            request.UserAgent = UserAgent;
            request.Expect = Expect;
            request.ContentLength = pByte.Length;
            stream = request.GetRequestStream();
            stream.Write(pByte, 0, pByte.Length);

            response = (HttpWebResponse)request.GetResponse();
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
