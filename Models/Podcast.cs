using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Models
{
    [Serializable]
    public class Podcast : Entity, ITitleable
    {
        public string Url { get; set; }
        public int UpdateFreq { get; set; }
        public int NumberOfEpisodes { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public string LastUpdatedTime { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public DateTime NextUpdate { get; set; }

        public List<Episode> Episodes = new List<Episode>();

        public override string EntityType()
        {
            return "A podcast.\n";
        }

        public Podcast(string url, string name, int updateFreq, string category)
        {
            Url = url;
            UpdateFreq = updateFreq;
            Category = category;
            NumberOfEpisodes = 0;
            Name = name;
            NumberOfEpisodes = this.Episodes.Count;
            Update();
        }

        public Podcast()
        {

        }
        public bool NeedsUpdate
        {
            get
            {
                return NextUpdate.Minute == DateTime.Now.Minute;
            }
        }

        public void Update()
        {
            NextUpdate = DateTime.Now.AddMinutes(UpdateFreq);
            createTitleAndDescription();
            createListOfEpisodes();
            NumberOfEpisodes = this.Episodes.Count;
            Console.WriteLine(Name + "'s Update() was invoked. Next update is at " + NextUpdate);
        }

        protected void createTitleAndDescription()
        {
            try
            {
                XmlReader reader = XmlReader.Create(Url);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                Title = feed.Title.Text;
                Description = feed.Description.Text;
                Language = feed.Language;
                LastUpdatedTime = feed.LastUpdatedTime.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void createListOfEpisodes()
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