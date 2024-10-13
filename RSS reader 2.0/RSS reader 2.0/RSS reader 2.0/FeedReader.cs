using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace RSS_reader_2._0
{
    public class FeedItems
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string PubDate { get; set; }
    }
    public class FeedReader {

        public IEnumerable<FeedItems> ReadFeed(string uri) {
            var feed = XDocument.Load(uri);
            var posts = from item in feed.Descendants("item")
                        select new FeedItems
                        {
                            Title=item.Element("title").Value,
                            Description = item.Element("description").Value,
                            Link = item.Element("link").Value,
                            PubDate = item.Element("pubDate").Value
                        };
            return posts;
        }
    }
}
