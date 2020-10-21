using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AutomatedRSSReader
{
    class Podcast
    {
        public string Url { get; set; }
        public string NumberOfEpisodes { get; set; }
        public SyndicationFeed feed { get; set; }

        public Podcast(string url)
        {
            Url = url;
            createFeed();
        }

        protected void createFeed()
        {
            XmlReader reader = XmlReader.Create(Url);
            SyndicationFeed feedTwo = SyndicationFeed.Load(reader);
            feed = feedTwo;
        }

    }
}


 