using HtmlAgilityPack;
using System.Collections.Generic;
using System.Linq;

namespace CompagnonYgg.Core.Services
{
    public class HtmlParseur
    {

        public IEnumerable<HtmlNode> Pars(string html)
        {
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var divs = htmlDocument.DocumentNode.Descendants("div")
                .Where(d => d.Attributes.Contains("class") && d.Attributes["class"].Value == "row");


            return divs;
        }


        public void ParsRow(HtmlNode divNode)
        {

            var divTitle = divNode.Descendants("div").FirstOrDefault(d => d.Attributes.Contains("class") && d.Attributes["class"].Value == "panel-title");

            var title = divTitle.InnerText.Trim();

            var tables = divNode.Descendants("table")
                .FirstOrDefault(T => T.Attributes.Contains("class") && T.Attributes["class"].Value == "table table-striped");


            var torrents = tables.Descendants("tr");

        }

        public void ParsTorrent(HtmlNode torrentNode)
        {

            var lines = torrentNode.Descendants("td").ToArray();



            var torrentName = lines[0].Descendants("a").FirstOrDefault(a => a.Attributes.Contains("class") &&
                                                           a.Attributes["class"].Value == "torrent-name");


            var torrentNameString = torrentName.InnerText.Trim();
            var torrentNameUrl = torrentName.Attributes["href"].Value.Trim();


            var uploader = lines[0].Descendants("i").FirstOrDefault(a => a.Attributes.Contains("class") &&
                                                                            a.Attributes["class"].Value == "fa fa-user");

            var uploaderName = uploader.InnerText.Trim();
            var uploaderUrl = uploader.Descendants("a").FirstOrDefault().Attributes["href"].Value.Trim();




            var ajouté = lines[1].InnerText.Trim();
            var size = lines[2].InnerText.Trim();
            var seeders = lines[3].InnerText.Trim();
            var leecher = lines[4].InnerText.Trim();



        }
    }
}
