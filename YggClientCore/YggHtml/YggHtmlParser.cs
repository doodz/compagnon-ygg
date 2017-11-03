using HtmlAgilityPack;
using System;
using System.Globalization;
using System.Linq;
using YggClientCore.User;

namespace YggClientCore.YggHtml
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
        private static void InfoTorrentFromInnerText(YggTorrentItem torrent, string innerText)
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
            InfoTorrentFromInnerText(item, torrentNode.InnerText);
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
        }

        public static UserRatio GetRatio(HtmlDocument doc)
        {
            var nodes = doc.DocumentNode.SelectNodes("//li[@class='submenu open']");
            var node = nodes.FirstOrDefault(n => n.InnerText.Contains("Ratio"));

            if (node == null) return null;

            var userRation = new UserRatio();
            var split = node.InnerText.Split(new[] { '\n', }, StringSplitOptions.RemoveEmptyEntries);


            var infosplit = split[0].Split(new[] { ' ', }, StringSplitOptions.RemoveEmptyEntries);
            userRation.Ration = double.Parse(infosplit[2], CultureInfo.InvariantCulture);
            userRation.Up = infosplit[3];

            userRation.Down = split[1];
            userRation.Actif = split[2].Contains("Actif");

            return userRation;

        }


        public static UserAccount GetUserAccount(HtmlDocument doc)
        {

            var userAccount = new UserAccount();

            var avatarNode = doc.DocumentNode.SelectSingleNode("//img[@alt='User avatar']");

            if (avatarNode != null)
            {
                var src = avatarNode.Attributes.FirstOrDefault(attri => attri.Name == "src");
                userAccount.Avatar = src?.Value;
            }

            //var bNodes = doc.DocumentNode.SelectNodes("//b']");
            //var tableNodes = doc.DocumentNode.SelectNodes("//table//tbody']");

            var node = doc.DocumentNode.SelectSingleNode("//div[@class='box-active']");
            var split = node.InnerText.Split(new[] { '\n', }, StringSplitOptions.RemoveEmptyEntries);


            userAccount.Pseudo = split[1];
            userAccount.Rank = split[3];
            userAccount.RegistrationDate = split[5];
            userAccount.Torrents = split[7];
            userAccount.Comments = split[9];
            userAccount.Reputation = split[11];


            return userAccount;

        }
    }
}