//using System;
//using System.Collections.Generic;
//using System.Text;
//using Data;
//using Models;
//using System.ServiceModel.Syndication;
//using System.Xml;
//using System.Linq.Expressions;

//namespace Business
//{
//    public class PodcastController : Podcast
//    {
//        protected void createTitleAndDescription()
//        {
//            try
//            {
//                XmlReader reader = XmlReader.Create(Url);
//                SyndicationFeed feed = SyndicationFeed.Load(reader);
//                Title = feed.Title.Text;
//                Description = feed.Description.Text;
//                Language = feed.Language;
//                LastUpdatedTime = feed.LastUpdatedTime.ToString();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//        public bool NeedsUpdate
//        {
//            get
//            {
//                return NextUpdate.Minute == DateTime.Now.Minute;
//            }
//        }

//        public void Update()
//        {
//            NextUpdate = DateTime.Now.AddMinutes(UpdateFreq);
//            createTitleAndDescription();
//            createListOfEpisodes();
//            NumberOfEpisodes = this.Episodes.Count;
//            Console.WriteLine(Name + "'s Update() was invoked. Next update is at " + NextUpdate);
//        }
//        public void createListOfEpisodes()
//        {
//            try {

//                XmlReader reader = XmlReader.Create(Url);
//                SyndicationFeed feed = SyndicationFeed.Load(reader);
//                reader.Close();

//                foreach (SyndicationItem item in feed.Items)
//                {
//                    string title = item.Title.Text;
//                    string description = item.Summary.Text;
//                    DateTimeOffset uploadDate = item.PublishDate;
//                    Episodes.Add(new Episode(title, description, uploadDate));
//                }
//            }catch (Exception e)
//            {
//                Console.WriteLine(e.Message);
//            }
//        }
//    }
//}
