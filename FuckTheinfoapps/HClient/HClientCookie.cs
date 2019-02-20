using System.Collections.Generic;
using System.Linq;

class HClientCookie
{
    public Dictionary<string, string> CookieDictionary;

    public HClientCookie()
    {
        CookieDictionary = new Dictionary<string, string>();
    }

    public HClientCookie(string _key, string _value)
    {
        CookieDictionary = new Dictionary<string, string>();
        CookieDictionary.Add(_key, _value);
    }

    public void AddCookie(string _key, string _value)
    {
        CookieDictionary.Add(_key, _value);
    }

    public void SetCookie(string _key, string _value)
    {
        CookieDictionary.Clear();
        CookieDictionary.Add(_key, _value);
    }

    public void SetCookie(Dictionary<string, string> _cookieKeyValuePairs)
    {
        if (_cookieKeyValuePairs == null)
            return;

        CookieDictionary.Clear();
        foreach (var dic in _cookieKeyValuePairs)
            CookieDictionary.Add(dic.Key, dic.Value);
    }

    public void Clear()
    {
        if (CookieDictionary != null)
            CookieDictionary.Clear();
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
