using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AutomatedRSSReader
{
    class OtherSerializer
    {
        public void Serialize(Podcast podcast)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(podcast.GetType());
            using (FileStream outFile = new FileStream("PodcastData.xml", FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, podcast);
            }
        }
        public void Serialize(List<Podcast> podcastList)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(podcastList.GetType());
            using (FileStream outFile = new FileStream("PodcastListData.xml", FileMode.Append, FileAccess.Write))
            {
                xmlSerializer.Serialize(outFile, podcastList);
            }
        }
        public Podcast Deserialize()
        {
            Podcast podcastObjToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Podcast));
            using (FileStream inFile = new FileStream("PodcastData.xml", FileMode.Open, FileAccess.Read))
            {
                podcastObjToBeReturned = (Podcast)xmlSerializer.Deserialize(inFile);
            }
            return podcastObjToBeReturned;
        }
        public List<Podcast> DeserializeList()
        {
            List<Podcast> listOfPodcastObjToBeReturned;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Podcast>));
            using (FileStream inFile = new FileStream("PodcastListdata.xml", FileMode.Open, FileAccess.Read))
            {
                listOfPodcastObjToBeReturned = (List<Podcast>)xmlSerializer.Deserialize(inFile);
            }
            return listOfPodcastObjToBeReturned;
        }
    }
}
