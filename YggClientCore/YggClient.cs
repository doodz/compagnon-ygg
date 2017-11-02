using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace YggClientCore
{
    public class YggClient
    {
        private CookieContainer _cookies;
        private HttpClientHandler _httpClientHandler;
        private readonly string _index = "https://yggtorrent.com";
        private readonly string _login = "https://yggtorrent.com/user/login";
        private readonly string _register = "https://yggtorrent.com/user/register";


        public YggClient()
        {
            _cookies = new CookieContainer();
            _httpClientHandler = new HttpClientHandler();
            _httpClientHandler.CookieContainer = _cookies;
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
            var html = await DownloadPageAsync(_index);

            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            IsConnected(doc);
        }


        public async Task<string> Seach()
        {
            var html = await DownloadPageAsync("https://yggtorrent.com/engine/search?q=toto&order=desc&sort=name");

            var doc = new HtmlDocument();
            doc.LoadHtml(html);

            var table = doc.DocumentNode.SelectSingleNode("//table//tbody");
            var torrents = table.ChildNodes.Where(n => n.Name == "tr");


            foreach (var torrent in torrents)
            {
                //
                //Toto le héros Jaco Van Dormael 1991 VFF XVID/ MPEG - 4 / MPEG - 3
                //
                //1
                //Uploadé par
                //Lgdr dans Film
                //
                //
                //1 mois
                //802.97MB
                //0
                //0
                var txt = torrent.InnerText.Split(new[] { '\n', }, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                var item = new YggTorrentItem();
                item.Name = txt[i++];
                if (txt.Length == 8)
                {
                    item.Comments = int.Parse(txt[i++]);
                }
                i += 2;
                //item.UploadedBy = txt[3];
                item.Age = txt[i++];
                item.Size = txt[i++];
                item.Seeders = int.Parse(txt[i++]);
                item.Leechers = int.Parse(txt[i++]);

                //item.Url
                //item.UrlUploader
                //item.TorrentId
                i = 0;
                var lstA = torrent.Descendants("a");

                var href = lstA.ElementAt(i++).Attributes.FirstOrDefault(attri => attri.Name == "href");
                item.UrlInfo = href?.Value;

                if (lstA.Count() == 6) i++;

                href = lstA.ElementAt(i++).Attributes.FirstOrDefault(attri => attri.Name == "href");
                item.UrlDownload = href?.Value;

                href = lstA.ElementAt(i).Attributes.FirstOrDefault(attri => attri.Name == "href");
                item.UrlUploader = href?.Value;
                item.UploadedBy = lstA.ElementAt(i++).InnerText;
                i++;
                href = lstA.ElementAt(i).Attributes.FirstOrDefault(attri => attri.Name == "target");
                item.TorrentId = int.Parse(href.Value);


            }

            return string.Empty;
        }

        public async Task LoginPage(string id, string pass)
        {
            //var html = await DownloadPageAsync(_login);
            await PostLogin(id, pass);
            await Index();
        }

        public async Task PostLogin(string id, string pass)
        {
            // id = doods & pass = *4teBFemJGb4EC8y625 % 25 & submit =
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
                using (var response = await client.PostAsync(_login, content))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        Console.WriteLine("Longin ok");
                        var responseCookies = _cookies.GetCookies(new Uri(_login)).Cast<Cookie>();
                    }
                }
            }
        }


        private bool IsConnected(HtmlDocument doc)
        {
            var link = doc.DocumentNode.SelectSingleNode("//a[@href='https://yggtorrent.com/user/login']");

            return link == null;
            //var links = doc.DocumentNode.SelectNodes("//a[@href]");
            //return links.All(l => l.InnerText != "Connexion");
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