using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using YggClientCore.Global;
using YggClientCore.Search;
using YggClientCore.YggHtml;

namespace YggClientCore
{
    public class YggClient
    {
        private readonly CookieContainer _cookies;
        private HttpClientHandler _httpClientHandler;
        private bool _islogged;
        public YggClient()
        {
            _cookies = new CookieContainer();
            _httpClientHandler = new HttpClientHandler { CookieContainer = _cookies };
        }

        //public async Task<IActionResult> Index()
        //{
        //    HttpClient hc = new HttpClient();
        //    HttpResponseMessage result = await hc.GetAsync($"http://{HttpContext.Request.Host}/page.html");

        //    Stream stream = await result.Content.ReadAsStreamAsync();

        //    HtmlDocument doc = new HtmlDocument();

        //    doc.Load(stream);

        //    HtmlNodeCollection links = doc.DocumentNode.SelectNodes("//a[@href]");//the parameter is use xpath see: https://www.w3schools.com/xml/xml_xpath.asp 

        //    return View(links);
        //}


        public async Task Index()
        {
            var html = await DownloadPageAsync(GlobalLocal.YggIndex);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            _islogged = YggHtmlParser.IsConnected(doc);
            if (_islogged)
                YggHtmlParser.GetRatio(doc);
        }

        public async Task Account()
        {

            var html = await DownloadPageAsync(GlobalLocal.YggAccount);
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            _islogged = YggHtmlParser.IsConnected(doc);
            if (_islogged)
                YggHtmlParser.GetUserAccount(doc);
        }

        public async Task<IEnumerable<YggTorrentItem>> Seach(string seachStr)
        {
            var builder = new SearchUrlBuilder();

            var url = builder.Search(seachStr, SortTorrent.name, OrderTorrent.desc);

            var html = await DownloadPageAsync(url);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var table = doc.DocumentNode.SelectSingleNode("//table//tbody");
            var torrents = table.ChildNodes.Where(n => n.Name == "tr");


            _islogged = YggHtmlParser.IsConnected(doc);
            var tmpLst = new List<YggTorrentItem>();
            foreach (var torrent in torrents)
                tmpLst.Add(YggHtmlParser.ParseTorrentHtml(torrent));

            return tmpLst;
        }

        public async Task LoginPage(string id, string pass)
        {
            //var html = await DownloadPageAsync(_login);
            await PostLogin(id, pass);
            await Index();
        }

        public async Task PostLogin(string id, string pass)
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.CookieContainer = _cookies;

            using (var client = new HttpClient(_httpClientHandler))
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("id", id),
                    new KeyValuePair<string, string>("pass", pass),
                    new KeyValuePair<string, string>("submit", string.Empty)
                });
                using (var response = await client.PostAsync(GlobalLocal.YggLogin, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("Longin ok");
                        var responseCookies = _cookies.GetCookies(new Uri(GlobalLocal.YggLogin)).Cast<Cookie>();
                    }
                }
            }
        }


        private async Task<string> DownloadPageAsync(string targetPage)
        {
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.CookieContainer = _cookies;
            // ... Use HttpClient.
            using (var client = new HttpClient(_httpClientHandler))
            using (var response = await client.GetAsync(targetPage))
            using (var content = response.Content)
            {
                // ... Read the string.
                var result = await content.ReadAsStringAsync();

                // ... Display the result.
                if (result != null &&
                    result.Length >= 50)
                    Console.WriteLine(result.Substring(0, 50) + "...");
                return result;
            }
        }
    }
}