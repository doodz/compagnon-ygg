using System;

namespace YggClientCore.Search
{
    public class SearchUrlBuilder : SearchBase
    {

        public string Search(string seachString)
        {
            return SearchUrlBase + System.Net.WebUtility.HtmlEncode(seachString);
        }

        public string Search(string seachString, SortTorrent sort, OrderTorrent order)
        {
            var url = SearchUrlBase + System.Net.WebUtility.HtmlEncode(seachString);

            url = AddOrder(new Tuple<string, OrderTorrent>(url, order));
            url = AddSort(new Tuple<string, SortTorrent>(url, sort));

            return url;
        }
    }
}