using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

class HClientCookie
{
    private Cookie cookie;
    public CookieContainer cookieContainer;

    public HClientCookie()
    {
        cookieContainer = new CookieContainer();
    }

    public HClientCookie(Uri _uri, string _key, string _value)
    {
        cookieContainer = new CookieContainer();
        cookie = new Cookie(_key, _value);
        cookieContainer.Add(_uri, cookie);
    }

    public void AddCookie(Uri _uri, string _key, string _value)
    {
        if (_uri == null)
            return;

        cookie = new Cookie(_key, _value);
        cookieContainer.Add(_uri, cookie);
    }

    public void SetCookie(Uri _uri, string _key, string _value)
    {
        if (_uri == null)
            return;

        cookieContainer = new CookieContainer();
        cookie = new Cookie(_key, _value);
        cookieContainer.Add(_uri, cookie);
    }

    public void SetCookie(Uri _uri, Dictionary<string, string> _cookieKeyValuePairs)
    {
        if (_uri == null || _cookieKeyValuePairs == null)
            return;

        cookieContainer = new CookieContainer();
        foreach (var pair in _cookieKeyValuePairs)
        {
            cookie = new Cookie(pair.Key, pair.Value);
            cookieContainer.Add(_uri, cookie);
        }
    }

    public string GetResponseCookie(HClient _client)
    {
        if (_client.Response == null || _client.Response.Headers == null)
            return null;

        var collection = _client.Response.Headers;
        if (collection.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            return values.First();

        return null;
    }
}
