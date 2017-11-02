using HtmlAgilityPack;
using System;
using System.Linq;

namespace YggClientCore.Torrents
{
    public class YggHtmlParser
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="torrent"></param>
        /// <param name="innerText"></param>
        /// <example>
        /// 
        ///
        ///Toto le héros Jaco Van Dormael 1991 VFF XVID/ MPEG - 4 / MPEG - 3
        ///
        ///1
        ///Uploadé par
        ///Lgdr dans Film
        ///
        ///
        ///1 mois
        ///802.97MB
        ///0
        ///0
        /// </example>
        public static void InfoFromInnerText(YggTorrentItem torrent, string innerText)
        {
            var i = 0;
            var txt = innerText.Split(new[] { '\n', }, StringSplitOptions.RemoveEmptyEntries);

            torrent.Name = txt[i++];
            if (txt.Length == 8)
            {
                torrent.Comments = int.Parse(txt[i++]);
            }
            i += 2;
            //item.UploadedBy = txt[3];
            torrent.Age = txt[i++];
            torrent.Size = txt[i++];
            torrent.Seeders = int.Parse(txt[i++]);
            torrent.Leechers = int.Parse(txt[i]);

        }

        public static YggTorrentItem ParseTorrentHtml(HtmlNode torrentNode)
        {

            var item = new YggTorrentItem();
            InfoFromInnerText(item, torrentNode.InnerText);
            GetValueFromANodes(item, torrentNode);

            return item;
        }

        private static void GetValueFromANodes(YggTorrentItem item, HtmlNode torrentNode)
        {
            var i = 0;
            var lstA = torrentNode.Descendants("a");

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


        public static bool IsConnected(HtmlDocument doc)
        {
            var link = doc.DocumentNode.SelectSingleNode("//a[@href='https://yggtorrent.com/user/login']");

            return link == null;
            //var links = doc.DocumentNode.SelectNodes("//a[@href]");
            //return links.All(l => l.InnerText != "Connexion");
        }
    }
}