using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text;
using System;

class HClient
{
    private HttpClient Client
    {
        get; set;
    }

    public HttpResponseMessage Response
    {
        get; set;
    }

    private Stream Stream
    {
        get; set;
    }

    private string ResponseContent
    {
        get; set;
    }

    private HttpContent PostContent
    {
        get; set;
    }

    private Image Image
    {
        get; set;
    }

    public string RequestUri
    {
        get; set;
    }

    public HClient()
    {
        Client = CreateInstance(false);
    }

    public HClient(HClientProxy _clientProxy)
    {
        Client = CreateInstance(true, _clientProxy.wProxy);
    }

    private HttpClient CreateInstance(bool useProxy, WebProxy proxy = null)
    {
        HttpClient client;
        Response = new HttpResponseMessage();
        HttpClientHandler handler = new HttpClientHandler();
        handler.UseCookies = false;
        handler.UseProxy = useProxy;
        handler.Proxy = proxy;
        client = new HttpClient(handler);

        return client;
    }

    private (HttpClient, HttpContent) CreateInstance(HttpClient _client, HClientCookie _clientCookie, HClientHeader _clientHeader, string _json = null)
    {
        HttpClient client = _client;
        HttpContent hContent = null;

        client.DefaultRequestHeaders.Clear();
        //Cookie
        if (_clientCookie != null && _clientCookie.CookieDictionary != null)
            foreach (var cookie in _clientCookie.CookieDictionary)
                client.DefaultRequestHeaders.TryAddWithoutValidation("Cookie", $"{cookie.Key}={cookie.Value}");

        //Default Http Request Header
        if (_clientHeader != null)
        {
            client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", _clientHeader.Accept);
            client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", _clientHeader.Referer);
            client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", _clientHeader.UserAgent);
        }

        //User Orijinal Headers
        if (_clientHeader != null && _clientHeader.headersKeyValuePairs != null)
            foreach (var header in _clientHeader.headersKeyValuePairs)
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);

        //User Post Paramaters
        if (_json != null)
        {
            hContent = new StringContent(_json, Encoding.UTF8, "application/json");
        }
        else if (_json == null && _clientHeader != null && _clientHeader.postKeyValuePairs != null)
        {
            var param = "";
            foreach (var ss in _clientHeader.postKeyValuePairs)
            {
                param += $"{ss.Key}={ss.Value}&";
            }
            hContent = new StringContent(param, Encoding.UTF8, "application/x-www-form-urlencoded");
        }

        return (client, hContent);
    }

    public async Task<string> Get(HClientCookie _clientCookie = null, HClientHeader _clientHeader = null)
    {
        var instance = CreateInstance(Client, _clientCookie, _clientHeader);
        Client = instance.Item1;
        try
        {
            Response = await Client.GetAsync(RequestUri);
            ResponseContent = await Response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ResponseContent = null;
        }

        return ResponseContent;
    }

    public async Task<Image> GetImage(HClientCookie _clientCookie = null, HClientHeader _clientHeader = null)
    {
        var instance = CreateInstance(Client, _clientCookie, _clientHeader);
        Client = instance.Item1;
        try
        {
            Response = await Client.GetAsync(RequestUri);
            Stream = await Response.Content.ReadAsStreamAsync();
            Image = Image.FromStream(Stream);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Image = null;
        }

        return Image;
    }

    public async Task<string> Post(HClientCookie _clientCookie = null, HClientHeader _clientHeader = null)
    {
        var instance = CreateInstance(Client, _clientCookie, _clientHeader);
        Client = instance.Item1;
        try
        {
            PostContent = instance.Item2;
            Response = await Client.PostAsync(RequestUri, PostContent);
            ResponseContent = await Response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ResponseContent = null;
        }

        return ResponseContent;
    }

    public async Task<string> Post(HClientCookie _clientCookie = null, HClientHeader _clientHeader = null, string _json = null)
    {
        var instance = CreateInstance(Client, _clientCookie, _clientHeader, _json);
        Client = instance.Item1;
        PostContent = instance.Item2;
        try
        {
            Response = await Client.PostAsync(RequestUri, PostContent);
            ResponseContent = await Response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ResponseContent = null;
        }

        return ResponseContent;
    }

    public HttpStatusCode GetResponseStatusCode()
    {
        if (Response == null)
            return 0;

        return Response.StatusCode;
    }

    public string GetResponseStatusString()
    {
        if (Response == null)
            return "0";

        return Response.StatusCode.ToString();
    }
}