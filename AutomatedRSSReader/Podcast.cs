using AutomatedRSSReader.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace AutomatedRSSReader
{
    class Podcast
    {
        public string Url { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Podcast(string url)
        {
            Url = url;
            createTitleAndDescription();
            createListOfEpisodes();
        }

        protected void createTitleAndDescription()
        {
            XmlReader reader = XmlReader.Create(Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            Title = feed.Title.Text;
            Description = feed.Description.Text;
        }

        protected void createListOfEpisodes()
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreComments = true;
            settings.IgnoreWhitespace = true;
            settings.IgnoreProcessingInstructions = true;

            List<Episode> episodeList = new List<Episode>();
            using (XmlReader episodeReader = XmlReader.Create(Url, settings))
            {
                
            }
        }
    }
}


 