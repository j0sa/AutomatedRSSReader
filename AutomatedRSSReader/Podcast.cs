﻿using AutomatedRSSReader.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace AutomatedRSSReader
{
    [Serializable]
    public class Podcast
    {
        public string Url { get; set; }
        public decimal UpdateFreq { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public List<Episode> Episodes = new List<Episode>();

        public Podcast(string url, decimal updateFreq, string category)
        {
            Url = url;
            UpdateFreq = updateFreq;
            Category = category;
            NumberOfEpisodes = 0;
            createTitleAndDescription();
            createListOfEpisodes();
            NumberOfEpisodes = this.Episodes.Count;
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

        protected void createListOfEpisodes()
        {
            XmlReader reader = XmlReader.Create(Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (SyndicationItem item in feed.Items)
            {
                string title = item.Title.Text;
                string description = item.Summary.Text;
                DateTimeOffset uploadDate = item.PublishDate;
                Episodes.Add(new Episode(title, description, uploadDate));
            }
        }
    }
}