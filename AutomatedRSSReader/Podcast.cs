﻿using AutomatedRSSReader.Properties;
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
    [Serializable]
    public class Podcast
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
            NumberOfEpisodes = 0;
        }

        public Podcast()
        {

        }

        protected void createTitleAndDescription()
        {
            try
            {
                XmlReader reader = XmlReader.Create(Url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Title = feed.Title.Text;
                Description = feed.Description.Text;
            } catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<Episode> createListOfEpisodes()
        {
            List<Episode> episodeList = new List<Episode>();
            XmlReader reader = XmlReader.Create(Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                NumberOfEpisodes++;
                string title = item.Title.Text;
                string description = item.Summary.Text;

                episodeList.Add(new Episode(title, description, NumberOfEpisodes));
            }
            return episodeList;
        }
    }
}