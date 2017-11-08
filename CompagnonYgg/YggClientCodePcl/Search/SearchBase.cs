using System;
using YggClientCodePcl.Global;

namespace YggClientCodePcl.Search
{
    public enum OrderTorrent
    {
        desc,
        asc
    }
    public enum SortTorrent
    {
        name,
        publish_date,
        size,
        seed,
        leech
    }
    public class SearchBase
    {
        protected string SearchUrlBase = $"{GlobalLocal.YggIndex}/engine/search?q=";

        protected string SearchUrlInCategory = $"{GlobalLocal.YggIndex}/engine/search?category=&subcategory=&q=";

        protected Func<Tuple<string, string>, string> SearchUrlInCategoryFormatter = tuple => $"{GlobalLocal.YggIndex}/engine/search?category={tuple.Item1}&subcategory={tuple.Item2}&q=";
        protected Func<Tuple<string, OrderTorrent>, string> AddOrder = tuple => $"{tuple.Item1}&order={tuple.Item2}";
        protected Func<Tuple<string, SortTorrent>, string> AddSort = tuple => $"{tuple.Item1}&sort={tuple.Item2}";

        //&order=desc&sort=name
        //&order=asc&sort=publish_date
        //&order=desc&sort=size
        //&order=desc&sort=seed
        //&order=desc&sort=leech

    }
}
