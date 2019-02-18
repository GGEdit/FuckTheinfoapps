using System.Drawing;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using System.Text;

class HClient
{
    private HttpClient Client
    {
        get; set;
    }

    private HttpRequestMessage Request
    {
        get; set;
    }

    public HttpResponseMessage Response
    {
        get; set;
    }

    public HttpClientHandler Handler
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
        Response = new HttpResponseMessage();
        Client = new HttpClient();
    }
    
    public HClient(HClientCookie _clientCookie)
    {
        Response = new HttpResponseMessage();

        HttpClientHandler handler = new HttpClientHandler();
        handler.UseCookies = true;
        if (_clientCookie != null && _clientCookie.cookieContainer != null)
            handler.CookieContainer = _clientCookie.cookieContainer;

        Client = new HttpClient(handler);
    }

    public HClient(HClientCookie _clientCookie, HClientProxy _clientProxy)
    {
        Response = new HttpResponseMessage();

        HttpClientHandler handler = new HttpClientHandler();
        handler.UseCookies = true;
        if (_clientCookie != null && _clientCookie.cookieContainer != null)
            handler.CookieContainer = _clientCookie.cookieContainer;

        handler.UseProxy = true;
        if (_clientProxy != null && _clientProxy.wProxy != null)
            handler.Proxy = _clientProxy.wProxy;

        Client = new HttpClient(handler);
    }
    
    private (HttpClient, HttpContent) CreateInstance(HttpClient _client, HClientHeader _clientHeader)
    {
        HttpClient client = _client;
        HttpContent hContent = null;
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.TryAddWithoutValidation("Accept", _clientHeader.Accept);
        client.DefaultRequestHeaders.TryAddWithoutValidation("Referer", _clientHeader.Referer);
        client.DefaultRequestHeaders.TryAddWithoutValidation("UserAgent", _clientHeader.UserAgent);

        //User Orijinal Headers
        if (_clientHeader != null && _clientHeader.headersKeyValuePairs != null)
            foreach (var header in _clientHeader.headersKeyValuePairs)
                client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);

        //User Post Paramaters
        if (_clientHeader != null && _clientHeader.postKeyValuePairs != null)
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

    public async Task<string> Get(HClientHeader _clientHeader = null)
    {
        var instance = CreateInstance(Client, _clientHeader);
        Client = instance.Item1;
        Response = await Client.GetAsync(RequestUri);
        ResponseContent = await Response.Content.ReadAsStringAsync();

        return ResponseContent;
    }

    public async Task<Image> GetImage(HClientHeader _clientHeader = null)
    {
        var instance = CreateInstance(Client, _clientHeader);
        Client = instance.Item1;
        Response = await Client.GetAsync(RequestUri);
        Stream = await Response.Content.ReadAsStreamAsync();
        Image = Image.FromStream(Stream);

        return Image;
    }

    public async Task<string> Post(HClientHeader _clientHeader = null)
    {
        var instance = CreateInstance(Client, _clientHeader);
        Client = instance.Item1;
        PostContent = instance.Item2;
        Response = await Client.PostAsync(RequestUri, PostContent);
        ResponseContent = await Response.Content.ReadAsStringAsync();

        return ResponseContent;
    }

    public async Task<string> Post(HClientHeader _clientHeader = null, string _json = null)
    {
        var instance = CreateInstance(Client, _clientHeader);
        Client = instance.Item1;
        PostContent = instance.Item2;
        Response = await Client.PostAsync(RequestUri, PostContent);
        ResponseContent = await Response.Content.ReadAsStringAsync();

        return ResponseContent;
    }

    public HttpStatusCode GetResponseStatusCode()
    {
        return Response.StatusCode;
    }

    public string GetResponseStatusString()
    {
        return Response.StatusCode.ToString();
    }
}